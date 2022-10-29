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
    private float _inputAngle;
    private float _speed;

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
        _normalozedDirection = new Vector3(_inputDirection.x, 0.0f, _inputDirection.y).normalized;
    }

    private void Move()
    {
        GetCurrentSpeed();

        if (_normalozedDirection.magnitude >= 0.1f || _playerLook._isAiming)
        {
            _inputAngle = Mathf.Atan2(_normalozedDirection.x, _normalozedDirection.z) * Mathf.Rad2Deg;
            float moveAngle = _inputAngle + _playerLook.MainCamera.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0.0f, moveAngle, 0.0f) * Vector3.forward;
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
        
        if (angle < -45f || angle > 45f)
            dampeAngle = 0f;

        if (angle == -135f)
            dampeAngle = angle + 180f;

        if(angle == 135f)
            dampeAngle = angle - 180f;

        return dampeAngle;
    } 

    private void PlayMoveAnimation()
    {
        _controlAnimations.SetMoveAnimation(_normalozedDirection.x, _normalozedDirection.z,
            _increaseSpeed.TargetSpeed, _increaseSpeed.RunSpeed);
    }
}
