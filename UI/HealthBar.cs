using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.HealthChanged += OnSetCurrentHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnSetCurrentHealth;
    }

    private void OnSetCurrentHealth(int value)
    {
        _text.text = value.ToString();
    }
}
