using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
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

    public void UpdateStats(ScriptableObject newItem)
    {
        ItemSlot.instance.nameBox.text = itemName;
        ItemSlot.instance.descriptionBox.text = itemDesc;
        ItemSlot.instance.imageIcon.sprite = itemIcon;
    }
    
    
}
