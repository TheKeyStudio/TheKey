using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Answer : MonoBehaviour
{
    private GameObject drag_Object = null;                 //古巴比倫物件 程式碼
    public string Answer;                                  //答案編號       (本身)
    
    public void ReplaceAndNewDragObjectIfExist(GameObject obj)                    //覆蓋物件方法判斷(obj) ->移動中的物件
    {    
        if(!GameObject.ReferenceEquals(drag_Object, null) && !GameObject.ReferenceEquals(obj, drag_Object)) //
        {                                                                              //摧毀答案框上的原物件
            Destroy(drag_Object);                                             
        }
        drag_Object = obj;                                                          //物件(一開始為null)=移動中的物件
    }

  

    private void OnTriggerExit2D(Collider2D other)     //離開答案框
    {
        if (GameObject.ReferenceEquals(other.gameObject, drag_Object))
        {
            Debug.Log("Exiting: " + drag_Object.name);
            drag_Object = null;                            //物件=null
        }
    }

    public bool IsAnswerEqual()                         //判斷答案正不正確
    {
        if (drag_Object == null)
        {
            return false;
        }
        Drag_Object obj = drag_Object.GetComponent<Drag_Object>();
        Debug.Log("答案" + obj.Number);
        Debug.Log("答案" + Answer.Equals(obj.Number)); 
        
        return Answer.Equals(obj.Number);                  //答案編號是否等於物件的編號  回傳布林值
        
    }

   


}
