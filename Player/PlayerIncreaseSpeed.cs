using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIncreaseSpeed : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _accelerationSpeed;

    public float CurrentSpeed { get; private set; }
    public float TargetSpeed { get; private set; }
    public float RunSpeed => _runSpeed;

    private PlayerLook _playerLook;
    private Vector3 _direction;
    private bool _isRunButtonPressed;
    private float _minSpeedValue = 0.0f;


    private void Awake()
    {
        _playerLook = GetComponent<PlayerLook>();
    }

    private void Update()
    {
        SetTargetSpeed();
        ChangeCurrentSpeed();
    }

    public void OnPressedRunButton(InputAction.CallbackContext callback)
    {
        _isRunButtonPressed = callback.action.IsPressed();
    }

    public float ReturnSpeed(Vector3 inputDirection)
    {
        _direction = inputDirection;
        return  CurrentSpeed;
    }

    private void ChangeCurrentSpeed()
    {
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, TargetSpeed, _accelerationSpeed * Time.deltaTime);

        if (CurrentSpeed < 0.01f)
            CurrentSpeed = _minSpeedValue;
    }

    private void SetTargetSpeed()
    {
        if (_isRunButtonPressed && !_playerLook._isAiming && _direction.z > 0)
            TargetSpeed = _runSpeed;
        else
            TargetSpeed = _walkSpeed;

        if (_direction.magnitude < 0.1f)
            TargetSpeed = _minSpeedValue;
    }
}
