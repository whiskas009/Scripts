using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _stepSounds;
    [SerializeField] private List<AudioClip> _equipmentSounds;
    [SerializeField] private AudioSource _audioSourceStepLeft;
    [SerializeField] private AudioSource _audioSourceEquipmentLeft;
    [SerializeField] private AudioSource _audioSourceStepRight;
    [SerializeField] private AudioSource _audioSourceEquipmentRight;

    public void OnPlayLeftStepSounds()
    {
        if (!_audioSourceStepLeft.isPlaying)
            _audioSourceStepLeft.PlayOneShot(GetRandomClip(_stepSounds));

        if (!_audioSourceEquipmentLeft.isPlaying)
            _audioSourceEquipmentLeft.PlayOneShot(GetRandomClip(_equipmentSounds));
    }

    public void OnPlayRightStepSounds()
    {
        if (!_audioSourceStepRight.isPlaying)
            _audioSourceStepRight.PlayOneShot(GetRandomClip(_stepSounds));

        if (!_audioSourceEquipmentRight.isPlaying)
            _audioSourceEquipmentRight.PlayOneShot(GetRandomClip(_equipmentSounds));
    }

    private AudioClip GetRandomClip(List <AudioClip> sounds)
    {
        int index = Random.Range(0, sounds.Count - 1);
        return sounds[index];
    }
}
