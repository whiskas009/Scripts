using DG.Tweening;
using UnityEngine;

public class FollowState : State
{
    [SerializeField] private float _speed;

    private float _timeChange = 5.0f;
    private float _timeRotate = 1.0f;

    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z), _speed * Time.deltaTime);
        _animator.SetFloat(_animatorHash.IdSpeed, Mathf.Lerp(_animator.GetFloat(_animatorHash.IdSpeed), _speed, _timeChange * Time.deltaTime));
        transform.DOLookAt(Target.transform.position, _timeRotate, AxisConstraint.Y);
    }
}
