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

        public int GetAnswerLength()
        {
            return answerText.Length;
        }

        public bool CheckAnswerText(string inputAnswer)
        {
            return answerText.Equals(inputAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }

    [Header("Answer Information")]
    public int levelNumber;
    [SerializeField]private List<Answer> answers;

    [Header("Input Field Generator")]
    public GameObject answerInputFieldGeneratorPrefab;
    [SerializeField]private List<SingleInputFieldGenerator> singleInputFieldList;

    public Computer computer;

    private void Start()
    {
        foreach (Answer answer in answers)
        {
            GameObject obj = Instantiate(answerInputFieldGeneratorPrefab) as GameObject;
            obj.transform.SetParent(transform, false);
            obj.SetActive(false);
            SingleInputFieldGenerator singleInputFieldScript = obj.GetComponent<SingleInputFieldGenerator>();
            singleInputFieldScript.CreateSingleInputField(answer.GetAnswerLength());
            singleInputFieldList.Add(singleInputFieldScript);
        }
        singleInputFieldList[0].SetActive(true); //show first one
    }

    public void CheckAnswerByIndex(int index)
    {
        string inputText = singleInputFieldList[index].GetInputListForStringFormat();
        bool isEqual = answers[index].CheckAnswerText(inputText);

        if (isEqual)
        {
            GameManager.instance.stage1++;
            Flowchart.BroadcastFungusMessage("答對了");
            computer.Close();
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
        Debug.Log("Answer is " + isEqual);
    }

    public void ChangeInputFieldByIndex(int index)
    {
        //deactive all and active the index
        foreach(SingleInputFieldGenerator singleInput in singleInputFieldList)
        {
            singleInput.SetActive(false);
        }
        singleInputFieldList[index].SetActive(true);
    }

}