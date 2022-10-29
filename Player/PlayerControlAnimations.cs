using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

[RequireComponent(typeof(AnimatorHash))]
[RequireComponent(typeof(AudioSource))]
public class PlayerControlAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rig _rigPlayerIdle;
    [SerializeField] private Rig _rigPlayerAim;
    [SerializeField] private float _speedChandeRig;
    [SerializeField] private Image _crosshair;
    [SerializeField] private Color _crosshairStartColor;
    [SerializeField] private Color _crosshairEndColor;
    [SerializeField] private bool isAuto;
    [SerializeField] private List<AudioClip> _aimSounds;

    private AnimatorHash _animatorHash;
    private AudioSource _audioSourceAim;
    private float _animatorInputX = 0;
    private float _animatorInputZ = 0;
    private float _maxRigWeight = 1.0f;
    private float _minRigWeight = 0.0f;
    private float _speedChangeValue = 10f;
    private float _timeSetColorCrosshair = 0.2f;
    private float _runInputAnimatorValue = 2.0f;
    private int _degreeRounding = 4;
    private bool _isFirstPlay = true;

    private void Start()
    {
        _animatorHash = GetComponent<AnimatorHash>();
        _audioSourceAim = GetComponent<AudioSource>();
    }

    public void SetMoveAnimation(float inputX, float inputZ, float targetSpeed, float runSpeed)
    {
        if (targetSpeed == runSpeed)
        {
            inputX = _runInputAnimatorValue;
            inputZ = _runInputAnimatorValue;
        }

        _animatorInputX = (float)Math.Round(Mathf.Lerp(_animatorInputX, inputX, _speedChangeValue * Time.deltaTime), _degreeRounding);
        _animatorInputZ = (float)Math.Round(Mathf.Lerp(_animatorInputZ, inputZ, _speedChangeValue * Time.deltaTime), _degreeRounding);

        if (inputX == 0 && Math.Abs(_animatorInputX) < 0.1f)
            _animatorInputX = 0;

        if (inputZ == 0 && Math.Abs(_animatorInputZ) < 0.1f)
            _animatorInputZ = 0;

        _animator.SetFloat(_animatorHash.IdInputX, _animatorInputX);
        _animator.SetFloat(_animatorHash.IdInputZ, _animatorInputZ);
    }

    public void SetAnimationRig(bool isIdleState = true)
    {
        if (isIdleState)
        {
            _rigPlayerIdle.weight = Mathf.Lerp(_rigPlayerIdle.weight, _maxRigWeight, _speedChandeRig * Time.deltaTime);
            _rigPlayerAim.weight = Mathf.Lerp(_rigPlayerAim.weight, _minRigWeight, _speedChandeRig * Time.deltaTime);
            _crosshair.DOColor(_crosshairStartColor, _timeSetColorCrosshair);
            PlayAimSound(1, false);
        }
        else
        {
            _rigPlayerIdle.weight = Mathf.Lerp(_rigPlayerIdle.weight, _minRigWeight, _speedChandeRig * Time.deltaTime);
            _rigPlayerAim.weight = Mathf.Lerp(_rigPlayerAim.weight, _maxRigWeight, _speedChandeRig * Time.deltaTime);
            _crosshair.DOColor(_crosshairEndColor, _timeSetColorCrosshair);
            PlayAimSound(0, true);
        }
    }

    private void PlayAimSound(int index, bool isFirstPlay = true)
    {
        if (_isFirstPlay == isFirstPlay)
        {
            _audioSourceAim.PlayOneShot(_aimSounds[index]);
            _isFirstPlay = !_isFirstPlay;
        }
    }
}
