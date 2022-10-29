using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LieState : State
{
    private float _speed = 0.0f;

    private void Update()
    {
        _animator.SetFloat(_animatorHash.IdSpeed, _speed);
    }
}
