using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Items/Item")]
public class Item : ScriptableObject {

    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
