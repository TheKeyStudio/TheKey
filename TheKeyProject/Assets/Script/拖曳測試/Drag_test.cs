using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Drag_test : MonoBehaviour {

    public bool  Test1 = false;
    public bool  Test2 = false;

    public void setTest1T()
    {
        Test1 = true;
    }
    public void SetTest1F()
    {
        Test1 = false;
    }
    public void setTest2T()
    {
        Test2 = true;
    }
    public void setTest2F()
    {
        Test2 = false;
    }

    public void Iscorrect()
    {
        if (Test1 && Test2)
        {
            Flowchart.BroadcastFungusMessage("答對了");
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
    }

    int[] array = new int[2];

    public void SetTest(int i)
    {
        array[i] = 1;
        Debug.Log(array[i]);
    }


}
