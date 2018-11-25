using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class BGMusic : MonoBehaviour {
    [Range(0.05f, 1f)]
    public float volumeScale = 1f;
    [Range(0f, 5f)]
    public float fadeTime = 1f;
    public bool persist = true;
    public bool autoStart = true;

    private AudioSource bgm;

    public void Awake()
    {
        bgm = GetComponent<AudioSource>();
        if(autoStart)
            StartBGM();
    }

    public void StartBGM()
    {
        bgm.StopLoopingMusicManaged();
        bgm.PlayLoopingMusicManaged(volumeScale, fadeTime, persist);
    }
    
}
