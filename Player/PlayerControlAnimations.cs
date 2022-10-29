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
    [SerializeField] private bool isAuto;
    [SerializeField] private List<AudioClip> _aimSounds;

    private AnimatorHash _animatorHash;
    private AudioSource _audioSourceAim;
    private float _animatorInputX = 0;
    private float _animatorInputZ = 0;
    private float _maxRigWeight = 1.0f;
    private float _minRigWeight = 0.0f;
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
            inputX = 2.0f;
            inputZ = 2.0f;
        }

        _animatorInputX = (float)Math.Round(Mathf.Lerp(_animatorInputX, inputX, 10f * Time.deltaTime), 4);
        _animatorInputZ = (float)Math.Round(Mathf.Lerp(_animatorInputZ, inputZ, 10f * Time.deltaTime), 4);

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
            _crosshair.DOColor(new Color(1.0f, 1.0f, 1.0f, 0.0f), 0.2f);
            PlayAimSound(1, false);
        }
        else
        {
            _rigPlayerIdle.weight = Mathf.Lerp(_rigPlayerIdle.weight, _minRigWeight, _speedChandeRig * Time.deltaTime);
            _rigPlayerAim.weight = Mathf.Lerp(_rigPlayerAim.weight, _maxRigWeight, _speedChandeRig * Time.deltaTime);
            _crosshair.DOColor(new Color(1.0f, 1.0f, 1.0f, 1.0f), 0.2f);
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
