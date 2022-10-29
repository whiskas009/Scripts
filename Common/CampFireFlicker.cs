using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class CampFireFlicker : MonoBehaviour
{
    [SerializeField] private float _minIntensity;
    [SerializeField] private float _maxIntensity;
    [SerializeField] private float _timeChange;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_light.DOIntensity(_minIntensity, _timeChange).SetEase(Ease.InOutBounce));
        sequence.Append(_light.DOIntensity(_maxIntensity, _timeChange).SetEase(Ease.OutBounce));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}
