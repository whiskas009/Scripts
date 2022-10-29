using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _audioMixer;

    public void OnSetVolume()
    {
        _audioMixer.SetFloat("MasterVolume", _slider.value);
    }
}
