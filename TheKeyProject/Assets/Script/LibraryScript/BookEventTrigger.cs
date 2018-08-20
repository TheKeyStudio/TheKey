using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEventTrigger : MonoBehaviour {
    public Animator animator;
    public Sound sound;
	// Use this for initialization
	void Start () {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;

        animator = gameObject.GetComponent<Animator>();
    }
	
	public void SoundEventTrigger()
    {
        sound.source.Play();
    }

    public void FallingAnimationTrigger()
    {
        animator.SetTrigger("Falling");
    }
}
