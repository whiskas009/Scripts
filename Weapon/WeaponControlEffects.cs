using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponControlEffects : MonoBehaviour
{
    [SerializeField] private MuzzleFlash _muzzleFlash;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private AudioSource _reloadSound;

    private WeaponRecoil _recoil;

    private void Start()
    {
        _recoil = GetComponent<WeaponRecoil>();
    }

    public void PlayEffects()
    {
        _shootSound.PlayOneShot(_shootSound.clip);
        _muzzleFlash.PlayOneShot();
        _recoil.GenerateRecoil();
    }

    public void PlayReloadSound()
    {
        _reloadSound.PlayOneShot(_reloadSound.clip);
    }
}
