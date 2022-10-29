using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _damageDistance;

    private WaitForSecondsRealtime _waitTime;
    private float _timeRotate = 1.0f;

    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(_attackDelay);
    }

    private void Update()
    {
        transform.DOLookAt(Target.transform.position, _timeRotate, AxisConstraint.Y);
    }

    private void OnEnable()
    {
        _animator.SetBool(_animatorHash.IdIsAttack, true);
        StartCoroutine(OnAttack());
    }

    private void OnDisable()
    {
        _animator.SetBool(_animatorHash.IdIsAttack, false);
        StopCoroutine(OnAttack());
    }

    private IEnumerator OnAttack()
    {
        while (enabled)
        {
            yield return _waitTime;

            if ((transform.position - Target.transform.position).sqrMagnitude < _damageDistance)
                Target.TakeDamage(_damage);
        }  
    }
}
