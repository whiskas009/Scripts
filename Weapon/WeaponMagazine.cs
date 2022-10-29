using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMagazine : MonoBehaviour
{
    [SerializeField] private WeaponReload _weaponReload;
    [SerializeField] private int _quantityAmmo;
    [SerializeField] private AudioSource _takeSound;

    private PlayerInputActions _inputActions;

    private void Start()
    {
        _takeSound = FindObjectOfType<TakeSound>().GetComponent<AudioSource>();
        _weaponReload = FindObjectOfType<WeaponReload>();
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _inputActions.Player.Take.performed += OnTakeMagazine;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _inputActions.Player.Take.performed -= OnTakeMagazine;
    }

    private void OnTakeMagazine(InputAction.CallbackContext context)
    {
        _takeSound.Play();
        _weaponReload.FillAmmo(_quantityAmmo);
        _inputActions.Player.Take.performed -= OnTakeMagazine;
        Destroy(gameObject);
    }
}
