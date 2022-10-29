using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class WeaponFlashlight : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    private AudioSource _flashlightSound;
    private PlayerInputActions _inputActions;

    private void Start()
    {
        _flashlightSound = GetComponent<AudioSource>();
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Player.FlashLight.performed += OnEnableFlashlight;
    }

    private void OnEnableFlashlight(InputAction.CallbackContext context)
    {
        _flashlightSound.Play();
        _light.SetActive(!_light.activeSelf);
    }
}
