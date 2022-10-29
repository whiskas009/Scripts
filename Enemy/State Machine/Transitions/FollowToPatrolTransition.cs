using UnityEngine;

public class FollowToPatrolTransition : Transition
{
    [SerializeField] private TargetSearchRadius _targetSearchRadius;

    public override State TryReturnNextState()
    {
        if (!_targetSearchRadius.IsTargetFound)
            return TargetState;

        return null;
    }
}
