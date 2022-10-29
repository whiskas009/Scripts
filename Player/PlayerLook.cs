using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControlAnimations))]
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private CameraControl _cameraControl;
    
    public bool _isAiming { get; private set; }
    public float _currentCameraAngle { get; private set; }
    public Transform MainCamera => _mainCamera;

    private PlayerControlAnimations _controlAnimations;

    private void Start()
    {
        _controlAnimations = GetComponent<PlayerControlAnimations>();
    }

    private void Update()
    {
        SetPlayerLook();
    }

    public void OnAimButtonPressed(InputAction.CallbackContext context)
    {
        _isAiming = context.action.IsPressed();
    }

    private void SetPlayerLook() 
    {
        if (_isAiming)
        {
            _cameraControl.SetCameraValue(true);
            _controlAnimations.SetAnimationRig(false);
        }
        else
        {
            _cameraControl.SetCameraValue(false);
            _controlAnimations.SetAnimationRig(true);
        }
    }
}
