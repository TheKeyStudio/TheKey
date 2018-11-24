using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class BGMusic : MonoBehaviour {
    public GameObject bgmPrefab;
    [Range(0f, 5f)]
    public float fadeTime;
    public bool persist = true;

    private AudioSource bgm;

    public void Awake()
    {
        bgm = Instantiate(bgmPrefab).GetComponent<AudioSource>();
        StartBGM();
    }

    public void StartBGM()
    {
        bgm.PlayLoopingMusicManaged(1f, fadeTime, persist);
    }
}
