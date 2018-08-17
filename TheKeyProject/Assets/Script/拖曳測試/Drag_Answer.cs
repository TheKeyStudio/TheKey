using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Answer : MonoBehaviour
{
    private Drag_Object drag_Object;                 //古巴比倫物件 程式碼
    private bool isAnswerEqual;                      //判斷答案正不正確 (古巴比倫編號 == 答案編號)  
    private string Number;                           //古巴比倫編號   (外來)
    public string Answer;                            //答案編號       (本身)
    private bool IsMouseup = false;

    public bool IsAnswerEqual
    {
        get
        {
            return isAnswerEqual;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)  //發生碰撞   other=古巴比倫
    {
        if(other.tag== "DragObject")                 //判斷是不是古巴比倫的標籤
        {
            ReplaceAndNewDragObjectIfExist(other.GetComponent<Drag_Object>());//覆蓋物件方法 (同一個答案框 只能出現一個物件)
            isAnswerEqual = CheckAnswer();                                          //判斷答案正不正確  回傳true or false
        }
    }

    private void ReplaceAndNewDragObjectIfExist(Drag_Object obj)                    //覆蓋物件方法判斷(Drag_Object obj) ->移動中的物件
    {
        if(drag_Object != null )                                                     //如果答案框上已經有物件了 
        {                                                                              //摧毀答案框上的原物件
            drag_Object.DestroyMe();                                               
        }
        drag_Object = obj;                                                          //物件(一開始為null)=移動中的物件
    }

    private void OnTriggerExit2D(Collider2D other)     //離開答案框
    {
        drag_Object = null;                            //物件=null
        isAnswerEqual = false;                         //答案=false
    }

    private bool CheckAnswer()                         //判斷答案正不正確
    {
        Number = drag_Object.Number;                   //古巴比倫編號=物件的編號
        Debug.Log("答案" + Answer.Equals(Number));     

        return Answer.Equals(Number);                  //答案編號是否等於物件的編號  回傳布林值
    }

   


}
