using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerSlot : Slot, IDropHandler {
    [SerializeField] private int answer;

    public bool IsCorrect
    {
        get
        {
            if(Item == null)
            {
                return false;
            }
            Babylon babylon = Item.GetComponent<Babylon>();
            return answer == babylon.Number;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Clear();
        Babylon.itemBeingChoose.transform.SetParent(transform);
    }

    public void Clear()
    {
        if(Item != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    public void Put(GameObject babyloneObj)
    {
        babyloneObj.transform.SetParent(transform);
    }
}
