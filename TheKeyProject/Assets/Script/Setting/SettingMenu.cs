using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    private float lastVolume;

	public void SetVolume(float volume)
    {
        lastVolume = volume;
        audioMixer.SetFloat("volume", volume);
    }

    public void ResumeLastVolume()
    {
        audioMixer.SetFloat("volume", lastVolume);
    }

    public void MuteVolume()
    {
        audioMixer.SetFloat("volume", -80f);
    }

    public void QuitGame()
    {
        SaveSystemManager.Save();
        Application.Quit();
    }
}
