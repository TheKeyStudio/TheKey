using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BabylonSlot : MonoBehaviour, IDropHandler {
    public GameObject Item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Item != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        DragHandler.itemBeingDragged.transform.SetParent(transform);
    }
}
