using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AnswerGroup : MonoBehaviour {

    [Serializable]
    private class Answer
    {
        [SerializeField]
        private string answerText;

        public string AnswerText
        {
            get
            {
                return answerText;
            }
        }

        public int GetAnswerLength()
        {
            return AnswerText.Length;
        }

        public bool CheckAnswerText(string inputAnswer)
        {
            return AnswerText.Equals(inputAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Header("Answer Information")]
    public int stage;
    public int levelNumber;
    [SerializeField]private List<Answer> answers;

    [Header("Input Field Generator")]
    public GameObject answerInputFieldGeneratorPrefab;
    [SerializeField]private List<SingleInputFieldGenerator> singleInputFieldList;
    private int currentIndex = -1;
    
    public GameObject submitButton;

    private void Start()
    {
        foreach (Answer answer in answers)
        {
            GameObject obj = Instantiate(answerInputFieldGeneratorPrefab) as GameObject;
            obj.transform.SetParent(transform, false);
            obj.SetActive(false);
            SingleInputFieldGenerator singleInputFieldScript = obj.GetComponent<SingleInputFieldGenerator>();
            singleInputFieldScript.SetAnswer(answer.AnswerText);
            singleInputFieldList.Add(singleInputFieldScript);
        }
        singleInputFieldList[0].SetActive(true);
        singleInputFieldList[0].ChangeActivateInputField();
        currentIndex = 0;
    }
    

    public void CheckAnswer()
    {
        string inputText = singleInputFieldList[currentIndex].GetInputListForStringFormat();
        bool isEqual = answers[currentIndex].CheckAnswerText(inputText);

        if (isEqual)
        {
            Flowchart.BroadcastFungusMessage("答對了");

            Debug.Log("Answer is Corret");
            submitButton.SetActive(false);
            singleInputFieldList[currentIndex].DoneAnswer();
        }
        else
        {
            Debug.Log("Answer is Wrong");
            Flowchart.BroadcastFungusMessage("答錯了");
        }

        if (AllAnswerIsSolved())
        {
            GameManager.instance.NextLevel(stage);
            Flowchart.BroadcastFungusMessage("全部答對了");
            Debug.Log("全部答對了");
        }
    }

    public void ChangeInputFieldByIndex(int index)
    {
        //if wanna index is not equal current index, then disative current input field and active wanna input field
        if(index != currentIndex)
        {
            singleInputFieldList[currentIndex].SetActive(false);
            singleInputFieldList[index].SetActive(true);
            singleInputFieldList[index].ChangeActivateInputField();
            currentIndex = index;
        }

        CheckAnswerIsSolvedAndAction();
    }

    private void CheckAnswerIsSolvedAndAction()
    {
        //if already done answer, then set ative of submit button to false
        if (singleInputFieldList[currentIndex].IsSolved)
        {
            submitButton.SetActive(false);
        }
        else
        {
            submitButton.SetActive(true);
        }
    }

    private bool AllAnswerIsSolved()
    {
        bool isSolved = true;
        foreach(SingleInputFieldGenerator s in singleInputFieldList)
        {
            isSolved = isSolved && s.IsSolved;
        }
        return isSolved;
    }

}