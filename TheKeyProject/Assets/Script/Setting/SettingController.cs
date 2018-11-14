using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour {

    private static bool GameIsPaused = false;

    public GameObject menu;
    public GameObject menuBtn;

    private void Update()
    {
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        menuBtn.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        menuBtn.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
