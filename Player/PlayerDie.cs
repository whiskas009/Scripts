using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;
    [SerializeField] private TMP_Text _respawnText;

    private float _textAlfa = 1.0f;
    private float _timeChange = 1.5f;
    private int _numbersLoops = 6;

    public void Respawn(ref int currentHealth, int maxHealth)
    {
        transform.position = _respawnPoint.position;
        currentHealth = maxHealth;
        _respawnText.DOFade(_textAlfa, _timeChange).SetEase(Ease.Linear).SetLoops(_numbersLoops, LoopType.Yoyo);
    }
}
