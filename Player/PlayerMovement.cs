using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerIncreaseSpeed))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerControlAnimations))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerControlAnimations _controlAnimations;
    private PlayerLook _playerLook;
    private PlayerRotation _playerRotation;
    private PlayerIncreaseSpeed _increaseSpeed;
    private CharacterController _controller;
    private Vector2 _inputDirection;
    private Vector3 _normalozedDirection;
    private float _speed;
    private float _inputAngle;
    private float _forwardDiagonalValueAngle = 45.0f;
    private float _backDiagonalValueAngle = 135.0f;
    private float _turnValueAngle = 180.0f;
    private float _lockAxisValue = 0.0f;

    private void Awake()
    {
        _playerLook = GetComponent<PlayerLook>();
        _playerRotation = GetComponent<PlayerRotation>();   
        _increaseSpeed = GetComponent<PlayerIncreaseSpeed>();
        _controller = GetComponent<CharacterController>();
        _controlAnimations = GetComponent<PlayerControlAnimations>();
    }

    private void Update()
    {
        Move();
        PlayMoveAnimation();
    }

    public void SetDirection(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
        _normalozedDirection = new Vector3(_inputDirection.x, _lockAxisValue, _inputDirection.y).normalized;
    }

    private void Move()
    {
        GetCurrentSpeed();

        if (_normalozedDirection.magnitude >= 0.1f || _playerLook._isAiming)
        {
            _inputAngle = Mathf.Atan2(_normalozedDirection.x, _normalozedDirection.z) * Mathf.Rad2Deg;
            float moveAngle = _inputAngle + _playerLook.MainCamera.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(_lockAxisValue, moveAngle, _lockAxisValue) * Vector3.forward;
            _controller.Move(moveDirection.normalized * _speed * Time.deltaTime);
            _playerRotation.Rotate(DampeAngle(_inputAngle) + _playerLook.MainCamera.eulerAngles.y);
        }
    }

    private void GetCurrentSpeed()
    { 
        _speed = _increaseSpeed.ReturnSpeed(_normalozedDirection);
    }

    private float DampeAngle(float angle)
    {
        float dampeAngle = angle;
        
        if (angle < -_forwardDiagonalValueAngle || angle > _forwardDiagonalValueAngle)
            dampeAngle = 0f;

        if (angle == -_backDiagonalValueAngle)
            dampeAngle = angle + _turnValueAngle;

        if(angle == _backDiagonalValueAngle)
            dampeAngle = angle - _turnValueAngle;

        return dampeAngle;
    } 

    private void PlayMoveAnimation()
    {
        _controlAnimations.SetMoveAnimation(_normalozedDirection.x, _normalozedDirection.z,
            _increaseSpeed.TargetSpeed, _increaseSpeed.RunSpeed);
    }
}
