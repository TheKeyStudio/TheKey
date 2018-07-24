using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Digital : MonoBehaviour {
    GameManager gameManager;
    public Flowchart flowchart;
    public GameObject Level1;
    public int num1;
    public int num2;
    public int num3;
    public int num4;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void isCorrect()
    {
        int _num1 = flowchart.GetIntegerVariable("數字1");
        int _num2 = flowchart.GetIntegerVariable("數字2");
        int _num3 = flowchart.GetIntegerVariable("數字3");
        int _num4 = flowchart.GetIntegerVariable("數字4");
        if ((_num1 == num1) && (_num2 == num2) && (_num3 == num3) && (_num4 == num4))
        {
            Debug.Log("correct");
            Flowchart.BroadcastFungusMessage("答對了");
            gameManager.game1 = true;
            gameManager.playerMove();
            gameObject.SetActive(false);
            Level1.SetActive(true);
        }
    }


}
