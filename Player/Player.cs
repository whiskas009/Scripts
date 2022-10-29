using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _amountHealthRecover;
    [SerializeField] private int _recoverDelay;

    public UnityAction<int> HealthChanged;

    private PlayerDie _playerDie;
    private WaitForSecondsRealtime _waitTime;
    private int _maxHealth = 100;
    private bool _isCoroutineWork = false;

    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(_recoverDelay);
        _playerDie = GetComponent<PlayerDie>();
        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
            _playerDie.Respawn(ref _currentHealth, _maxHealth);

        if (!_isCoroutineWork)
            StartCoroutine(OnRecoverHealth());

        HealthChanged?.Invoke(_currentHealth);
    }

    private IEnumerator OnRecoverHealth()
    {
        _isCoroutineWork = true;
        
        while (_currentHealth != _maxHealth)
        {
            yield return _waitTime;
            _currentHealth += _amountHealthRecover;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            HealthChanged?.Invoke(_currentHealth);
        }

        _isCoroutineWork = false;
        StopCoroutine(OnRecoverHealth());
    } 
}
