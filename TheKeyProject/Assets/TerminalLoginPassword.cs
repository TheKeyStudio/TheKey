using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalLoginPassword : MonoBehaviour {

    public GameObject loadingImg;
    public TMP_Text messageText;
    public SingleInputFieldGenerator singleInputFieldGenerator;

    public float maxRandomLoadingSecond = 5f;

    [SerializeField]
    private string answerText;
    private bool isAnswerCorrect = false;
    private bool onLoading = false;
    private float loadingTime = 0f;

    // Use this for initialization
    void Start () {
        singleInputFieldGenerator.SetAnswer(answerText);
        singleInputFieldGenerator.ChangeActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("onloading" + onLoading);
            Debug.Log("Issolved" + singleInputFieldGenerator.IsSolved);
            if (!onLoading)
            {
                Loading();
            }
        }
        if (onLoading)
        {
            loadingTime -= Time.deltaTime;
            Debug.Log(loadingTime);
            if (0 > loadingTime)
            {
                UnLoading();
            }
        }
    }

    private void UnLoading()
    {
        Debug.Log("Unloading");
        onLoading = false;
        loadingImg.SetActive(false);
        singleInputFieldGenerator.SetActive(true);
        RefreshMessageText();
        singleInputFieldGenerator.ChangeActivateInputField();
    }

    public void Loading()
    {
        Debug.Log("Loading");
        CheckAnswer();
        onLoading = true;
        singleInputFieldGenerator.SetActive(false);
        loadingImg.SetActive(true);
        loadingTime = Random.Range(0.5f, maxRandomLoadingSecond);
        ResetMessageText();
        Debug.Log(loadingTime);
    }

    private void CheckAnswer()
    {
        isAnswerCorrect = singleInputFieldGenerator.IsSolved;
        Debug.Log("Answer is " + isAnswerCorrect);
    }

    private void ResetMessageText()
    {
        messageText.text = "";
    }

    private void RefreshMessageText()
    {
        if (isAnswerCorrect)
        {
            messageText.text = "答對了";
        }
        else
        {

            messageText.text = "答錯了";
        }
    }
}
