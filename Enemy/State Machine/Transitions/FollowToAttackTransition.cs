using UnityEngine;

public class FollowToAttackTransition : Transition
{
    [SerializeField] private float _range;
    
    public override State TryReturnNextState()
    {
        if ((transform.position - Target.transform.position).sqrMagnitude < _range)
              return TargetState;

        return null;
    }
}
