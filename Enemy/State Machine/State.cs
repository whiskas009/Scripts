using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition>  _transitions;
    [SerializeField] private AudioSource _zombieStateSound;
    [SerializeField] private bool _isStopPlayAfterDisableState;

    public List<Transition> Transitions => _transitions;

    protected Animator _animator;
    protected AnimatorHash _animatorHash;
    protected Player Target { get; private set; }

    private void OnEnable()
    {
        if (_zombieStateSound != null & _zombieStateSound.isPlaying == false)
            _zombieStateSound.Play();
    }

    private void OnDisable()
    {
        if (_zombieStateSound != null & _isStopPlayAfterDisableState)
            _zombieStateSound.Stop();
    }

    public void Enter(Player target, Animator animator, AnimatorHash animatorHash)
    {
        if (enabled == false)
        {
            Target = target;
            _animator = animator;
            _animatorHash = animatorHash;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            State state = transition.TryReturnNextState();

            if (state != null)
                return state;
        }

        return null;
    }
}
