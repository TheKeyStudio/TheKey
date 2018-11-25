using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class PlaySound : MonoBehaviour {
    AudioSource audioSource;

    [Range(0.05f, 1f)]
    public float volumeScale = 1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShotSound()
    {
        audioSource.PlayOneShotSoundManaged(audioSource.clip, volumeScale);
    }

    public void PlayLoopSound()
    {
        audioSource.PlayLoopingSoundManaged(volumeScale, 2f);
    }
    
}
