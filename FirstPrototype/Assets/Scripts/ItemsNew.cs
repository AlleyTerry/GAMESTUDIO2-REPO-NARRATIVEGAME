using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Item", 
                    menuName = "New Item",
                    order = 0)]

public class ItemsNew : ScriptableObject
{
    public static ItemsNew instance;
    public string itemName;
    public string itemDesc;
    public Sprite itemIcon;

    public void UpdateStats(ItemSlot newItem)
    {
        Debug.Log("is this here: " + newItem);
        newItem.nameBox.text = itemName;
        newItem.descriptionBox.text = itemDesc;
        newItem.imageIcon.sprite = itemIcon;
    }
    
    
}
