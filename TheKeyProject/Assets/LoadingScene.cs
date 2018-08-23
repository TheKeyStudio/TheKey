using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public static LoadingScene instance;

    private Animator animator;
    private string sceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            animator = gameObject.GetComponent<Animator>();
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }


    public void FadeToScene(string sceneName)
    {
        this.sceneName = sceneName;
        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
        animator.SetBool("FadeOut", false);
    }

    public void FadeIn()
    {
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
