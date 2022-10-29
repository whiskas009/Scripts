using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ZombieFallSound : MonoBehaviour
{
    private AudioSource _fallSound;

    private void Start()
    {
        _fallSound = GetComponent<AudioSource>();
    }

    public void OnPlayFallSound()
    {
        _fallSound.Play();
    }
}
