using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public GameObject itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        Inventory.instance.onItemChangedCallBack = null;
        if (inventory.onItemChangedCallBack == null)
            inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
	}
    

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                Debug.Log(slots[i].name + " : " + inventory.items[i].name);
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


    public void InventoryButtonOnClick()
    {
        Debug.Log("Inventory button clicked");
        itemsParent.SetActive(!itemsParent.activeSelf);
    }
}
