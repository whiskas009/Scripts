using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _audioMixer;

    private float _minSliderValue = -20f;
    private float _minMasterValume = -80f;
    
    public void OnSetVolume()
    {
        _audioMixer.SetFloat("MasterVolume", _slider.value);

        if (_slider.value < _minSliderValue)
            _audioMixer.SetFloat("MasterVolume", _minMasterValume);
    }
}
