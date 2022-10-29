using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class IdleToFollowTransition : Transition
{
    [SerializeField] private TargetSearchRadius _targetSearchRadius;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override State TryReturnNextState()
    {
        if (_targetSearchRadius.IsTargetFound || _enemy.IsTakeDamage)
            return TargetState;
        
        return null;
    }
}
