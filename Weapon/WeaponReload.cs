using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponShooting))]
public class WeaponReload : MonoBehaviour
{
    [SerializeField] int _cartridgesInMagazine;
    [SerializeField] int _totalCartridges;
    [SerializeField] private float _timeReload;
    
    public UnityAction<int, int> CartrigesChanged;
    public int CurrentCartidges { get; private set; }
    public float CurrentTineReload { get; private set; }

    private Animator _reloadAnimator;
    private PlayerInputActions _playerInput;
    private WaitForFixedUpdate _waitTime;
    private WeaponShooting _weaponShooting;
    private bool _isCoroutineWeaponReloadWork = false;
    private int _indexIdleLayerAnimator = 1;
    private float _maxLayerAnimatorWeight = 1.0f;
    private float _minLayerAnimatorWeight = 0.0f;

    private void Start()
    {
        _weaponShooting = GetComponent<WeaponShooting>();
        _reloadAnimator = FindObjectOfType<WeaponReloadAnimator>().GetComponent<Animator>();
        _playerInput = new PlayerInputActions();
        _playerInput.Enable();
        _playerInput.Player.Reload.performed += OnStartReload;
        CurrentTineReload = 0.0f;
        CurrentCartidges = _cartridgesInMagazine;
        CartrigesChanged?.Invoke(CurrentCartidges, _totalCartridges);
    }

    public void ReduceAmmo()
    {
        if (CurrentCartidges > 0)
            CurrentCartidges -= 1;

        CartrigesChanged?.Invoke(CurrentCartidges, _totalCartridges);
    }

    public void FillAmmo(int quantityAmmo)
    {
        _totalCartridges += quantityAmmo;
        CartrigesChanged?.Invoke(CurrentCartidges, _totalCartridges);
    }

    private void OnStartReload(InputAction.CallbackContext context)
    {
        if (!_isCoroutineWeaponReloadWork && CurrentCartidges != _cartridgesInMagazine && _totalCartridges > 0)
            StartCoroutine(OnWeaponReload());
    }

    private IEnumerator OnWeaponReload()
    {
        _isCoroutineWeaponReloadWork = true;
        CurrentTineReload = _timeReload;
        PlayReloadEffects();

        while (CurrentTineReload > 0.1f)
        {
            SetReloadAnimation();
            CurrentTineReload -= Time.deltaTime;
            yield return _waitTime;
        }

        CalculateCurrentAmmo();

        _isCoroutineWeaponReloadWork = false;
        CartrigesChanged?.Invoke(CurrentCartidges, _totalCartridges);
        StopCoroutine(OnWeaponReload());
    }

    private void CalculateCurrentAmmo()
    {
        int shootedCartidges = _cartridgesInMagazine - CurrentCartidges;

        if (_totalCartridges >= shootedCartidges)
        {
            _totalCartridges -= shootedCartidges;
            CurrentCartidges += shootedCartidges;
        }
        else
        {
            CurrentCartidges += _totalCartridges;
            _totalCartridges = 0;
        }
    }

    private void SetReloadAnimation()
    {
        if (_weaponShooting.IsAim)
            _reloadAnimator.SetLayerWeight(_indexIdleLayerAnimator, _maxLayerAnimatorWeight);
        else
            _reloadAnimator.SetLayerWeight(_indexIdleLayerAnimator, _minLayerAnimatorWeight);
    }

    private void PlayReloadEffects()
    {
        _weaponShooting.ControlEffects.PlayReloadSound();
        _reloadAnimator.Play("WeaponReloadIdle");
        _reloadAnimator.Play("WeaponReloadAim");
    }
}
