using DG.Tweening;
using UnityEngine;

public class SetterEnvironmentSound : MonoBehaviour
{
    [SerializeField] private AudioReverbZone _reverbZone;
    [SerializeField] private AudioSource _forestSound;
    [SerializeField] private float _maxForestSoundVolume;
    [SerializeField] private AudioSource _tonelSound;
    [SerializeField] private float _maxTonelSoundVolume;
    [SerializeField] private float _timeChange;

    private float _minVolume = 0.0f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.TryGetComponent(out Player player))
        {
            _reverbZone.enabled = true;
            _tonelSound.DOFade(_maxTonelSoundVolume, _timeChange).SetEase(Ease.Linear);
            _forestSound.DOFade(_minVolume, _timeChange).SetEase(Ease.Linear);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.TryGetComponent(out Player player))
        {
            _reverbZone.enabled = false;
            _tonelSound.DOFade(_minVolume, _timeChange).SetEase(Ease.Linear);
            _forestSound.DOFade(_maxForestSoundVolume, _timeChange).SetEase(Ease.Linear);
        }
    }
}
