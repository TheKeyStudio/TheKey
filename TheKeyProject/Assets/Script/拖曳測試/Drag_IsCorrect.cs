using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Drag_IsCorrect : MonoBehaviour {
    public List<Drag_Answer> answers;
    private bool Finalanswer = false;

    public void CheckAllAnswers()               //判斷是否全部正確
    {
        foreach(Drag_Answer answer in answers)  //判斷全部的答案是否正確
        {
            Debug.Log(answer.IsAnswerEqual());
            if (answer.IsAnswerEqual())           //判斷該物件的布林是不是=true  
            {
                Finalanswer = true;
            }
            else
            {
                Finalanswer = false;            
            }
            if (!Finalanswer)                   //如果有一個不正確就跳開
            {
                break;
            }
        }
        Debug.Log("Finalanswer:" + Finalanswer);
        Iscorrect();
    }
    public void Iscorrect()             //答案驗證
    {
        if (Finalanswer)
        {
            Flowchart.BroadcastFungusMessage("答對了");
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
    }

}
