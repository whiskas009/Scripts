using System.Collections;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] private ParticleSystem _glow;
    [SerializeField] private ParticleSystem _plane2;
    [SerializeField] private ParticleSystem _plane3;
    [SerializeField] private ParticleSystem _plane4;
    [SerializeField] private ParticleSystem _sparks;
    [SerializeField] private Light _light;

    private float _lightDelay = 0.05f;
    private WaitForSecondsRealtime _waitTime;

    private void Start()
    {
        _waitTime = new WaitForSecondsRealtime(_lightDelay);
    }

    public void PlayOneShot()
    {
        _glow.Emit(1);
        _plane2.Emit(1);
        _plane3.Emit(1);
        _plane4.Emit(1);
        _sparks.Emit(1);
        StartCoroutine(PlayLightOneShot());
    }

    private IEnumerator PlayLightOneShot()
    {
        _light.enabled = true;
        yield return _waitTime;
        _light.enabled = false;
        StopCoroutine(PlayLightOneShot());
    }
}
