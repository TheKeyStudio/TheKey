
using UnityEngine;
using UnityEngine.EventSystems;

public class Babylon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int number;
    public static GameObject itemBeingChoose;
    Transform startParent;
    private bool clickMode = true;

    public int Number
    {
        get
        {
            return number;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        clickMode = false;
        itemBeingChoose = gameObject;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingChoose = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            Destroy(gameObject);
        }
        clickMode = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickMode)
        {
            AnswerSlotClickHandler.instance.Put(itemBeingChoose);
            itemBeingChoose = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (clickMode)
        {
            itemBeingChoose = gameObject;
        }
    }
}
