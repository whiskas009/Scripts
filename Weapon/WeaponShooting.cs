using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponReload))]
[RequireComponent(typeof(WeaponControlEffects))]
public class WeaponShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _shootDelay;
    [SerializeField] private LayerMask _layerRaycast;

    public bool IsAim => _isAim;
    public WeaponControlEffects ControlEffects => _controlEffects;

    private WeaponReload _weaponReload;
    private WeaponControlEffects _controlEffects;
    private bool _isShoot = false;
    private bool _isAim = false;
    private float _currentShootTime;
    private RaycastHit _hit;

    private void Start()
    {
        _currentShootTime = _shootDelay;
        _controlEffects = GetComponent<WeaponControlEffects>();
        _weaponReload = GetComponent<WeaponReload>();
    }

    private void Update()
    {
        Shoot();
    }

    public void OnShootBottonPressed(InputAction.CallbackContext callback)
    {
        _isShoot = callback.action.IsPressed();
    }

    public void OnAimBottonPressed(InputAction.CallbackContext callback)
    {
        _isAim = callback.action.IsPressed();
    }

    private void Shoot()
    {
        if (_isAim & _isShoot)
        {
            if (_currentShootTime < 0.01f & _weaponReload.CurrentCartidges > 0 & _weaponReload.CurrentTineReload  <= 0.1f)
            {
                _currentShootTime = _shootDelay;

                if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out _hit, Mathf.Infinity, _layerRaycast))
                {
                    _controlEffects.PlayEffects();
                    _weaponReload.ReduceAmmo();

                    if (_hit.transform.TryGetComponent(out Enemy enemy))
                        enemy.TakeDamage(_damage);
                }
            }
        }

        if (_currentShootTime > 0.0f)
            _currentShootTime -= Time.deltaTime;
    }
}
