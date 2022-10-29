using TMPro;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private WeaponReload _weaponReload;

    private void Awake()
    {
        _weaponReload = FindObjectOfType<WeaponReload>();
    }

    private void OnEnable()
    {
        _weaponReload.CartrigesChanged += OnSetCurrentAmmo;
    }

    private void OnDisable()
    {
        _weaponReload.CartrigesChanged -= OnSetCurrentAmmo;
    }

    private void OnSetCurrentAmmo(int currentCartidges, int totalCartidges)
    {
        _text.text = currentCartidges.ToString() + " / " + totalCartidges.ToString();
    }
}
