using System.Collections;
using UnityEngine;

public class AttackToFollowTransition : Transition
{
    [SerializeField] private float _range;
    [SerializeField] private float _transitionDelay;

    private float _currentTime;
    private WaitForFixedUpdate _waitTime;
    private bool _isCoroutineWork = false;

    private void Start()
    {
        _currentTime = _transitionDelay;
        _waitTime = new WaitForFixedUpdate();
    }

    public override State TryReturnNextState()
    {
        if (_currentTime < 0.1f)
            return TargetState;

        if ((transform.position - Target.transform.position).sqrMagnitude > _range && _isCoroutineWork == false)
            StartCoroutine(OnDoDelay());    

        return null;
    }

    private IEnumerator OnDoDelay()
    {
        _isCoroutineWork = true;
        
        while (_currentTime > 0.1f)
        {
            _currentTime -= Time.deltaTime;
            yield return _waitTime;
        }

        _isCoroutineWork = false;
        _currentTime = _transitionDelay;
        StopCoroutine(OnDoDelay());
    }
}
