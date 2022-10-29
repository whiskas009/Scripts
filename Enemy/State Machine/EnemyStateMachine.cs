using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;
    
    private Player _target;
    private Animator _animator;
    private AnimatorHash _animatorHash;
    private State _currentState;
    private State _nextState;

    public void StopStateMachine()
    {
        _currentState.Exit();
        enabled = false;
    }

    private void Start()
    {
        _animatorHash = GetComponent<Enemy>().AnimatorHash;
        _target = GetComponent<Enemy>().Target;
        _animator = GetComponent<Enemy>().Animator;
        SetStartState();
    }

    private void SetStartState()
    {
        _currentState = _startState;

        if (_currentState != null)
            _currentState.Enter(_target, _animator, _animatorHash);
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _nextState = _currentState.TryGetNextState();

            if (_nextState != null)
                Transit(_nextState);
        }
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_target, _animator, _animatorHash);
    }
}
