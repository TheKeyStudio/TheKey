using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSlotClickHandler : MonoBehaviour {
    public static AnswerSlotClickHandler instance;
    private BabylonAnswerChecker checker;
    private List<AnswerSlot> answerSlots;

    void Start () {
        if(instance == null)
        {
            instance = this;
        }
        checker = GetComponent<BabylonAnswerChecker>();
        answerSlots = checker.answerSlots;

    }
	
	public void Put(GameObject babylonObj)
    {
        foreach (AnswerSlot answer in answerSlots)  //判斷全部的答案是否正確
        {
            if (answer.Item == null)
            {
                answer.Put(babylonObj);
                break;
            }
        }
    }
}
