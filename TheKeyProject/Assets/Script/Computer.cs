using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class Computer : MonoBehaviour {

    // Use this for initialization

    public GameObject question;
    private bool active = false;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            active = true;
            Debug.Log(active);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            active = false;
            Debug.Log(active);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("hellow");
            if (active)
            {
                gameManager.playerStop();
                question.SetActive(true);
            }
        }
    }
}
