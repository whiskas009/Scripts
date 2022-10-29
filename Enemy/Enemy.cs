using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyStateMachine))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Player _target;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorHash _animatorHash;
    [SerializeField] private GameObject _zombiesSounds;

    public Player Target => _target;
    public Animator Animator => _animator;
    public AnimatorHash AnimatorHash => _animatorHash;
    public bool IsTakeDamage => _isTakeDamage;
    public bool IsDie => _isDie;

    private bool _isDie = false;
    private bool _isTakeDamage = false; 
    private EnemyStateMachine _stateMachine;
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    private void OnEnable()
    {
        _target = FindObjectOfType<Player>();
        _animatorHash = FindObjectOfType<AnimatorHash>();
        _stateMachine = GetComponent<EnemyStateMachine>();
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator.enabled = true;
        _stateMachine.enabled = true;
    }

    private void OnDisable()
    {
        _animator.enabled = false;
        _stateMachine.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        _isTakeDamage = true;
        _health -= damage;

        if (_health <= 0.0f)
            Die();
    }

    private void Die()
    {
        _isDie = true;
        _animator.SetBool(_animatorHash.IdIsDeath, true);
        _stateMachine.StopStateMachine();
        _zombiesSounds.SetActive(false);
        DisableController();
    }

    private void DisableController()
    {
        _rigidbody.isKinematic = true;
        _capsuleCollider.enabled = false;
    }
}
