using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Digital1 : MonoBehaviour {
    GameManager gameManager;
    public Flowchart flowchart;
   
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void isCorrect()
    {
        int a=  flowchart.GetIntegerVariable("數字1");
        int b = flowchart.GetIntegerVariable("數字2");
        int c = flowchart.GetIntegerVariable("數字3");
        int d = flowchart.GetIntegerVariable("數字4");


        if ((a == 1)  && (b == 2) && (c==2) && (d==1))
        {
            
            Debug.Log("correct");
            gameManager.game1 = true;
            //gameManager.ActiveMove();
        }
    }


}
