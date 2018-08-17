﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_Object : MonoBehaviour
{
    private Vector2 V2;              //物件的向量  
    private bool Enter;              //判斷是否進入答案框  Drag_Answer
    private bool alreadyCopy;        //判斷是否已經複製了
    public string Number;            //自己的編號
   

    

    //-------------------------------------------

    void Start()
    {
        V2 = transform.position;    //物件起始位置
        Enter = false;              //尚未進入
        alreadyCopy = false;        //尚未複製
    }                 //初始設定
    public void OnMouseUp()         //當滑鼠離開時執行
    {
        if (!alreadyCopy)           //沒有複製
        {
            copyFirst();            //複製一份
        }
        if (!Enter)                 //沒有進入
        {
            DestroyMe();            //摧毀物件
        }
       
    }
    public void copyFirst()         //複製物件
    {
        Instantiate(gameObject, V2, new Quaternion(0, 0, 0, 0));
        alreadyCopy = true;         //已經複製了，所以下一次無法複製
    }
    public void DestroyMe()
    {
        Destroy(gameObject);//摧毀物件
    }      

    private void OnTriggerEnter2D(Collider2D other)      // 判斷物件是否進入答案框  
    {
        if (other.tag == "AnswerBox")
        {
            Enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)       // 判斷物件是否離開答案框  
    {
        Enter = false;
    }

   
}
