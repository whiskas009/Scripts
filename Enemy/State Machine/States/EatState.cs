using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(CapsuleCollider))]
public class EatState : State
{
    private CapsuleCollider _defaultCollider;
    private BoxCollider _idleCollider;
    private float _speed = 0.0f;

    private void Awake()
    {
        _defaultCollider = GetComponent<CapsuleCollider>();
        _idleCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _defaultCollider.enabled = false;
        _idleCollider.enabled = true;
    }

    private void OnDisable()
    {
        _defaultCollider.enabled = true;
        _idleCollider.enabled = false;
    }

    private void Update()
    {
        _animator.SetFloat(_animatorHash.IdSpeed, _speed);
    }
}
