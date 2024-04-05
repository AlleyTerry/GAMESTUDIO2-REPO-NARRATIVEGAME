
using UnityEngine;




[CreateAssetMenu(menuName = "New InvenotryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public static InventoryItem instance;
    //public bool itemOwned = false;

    public string itemName;
    public Sprite itemIcon;
    public string itemDesc;

 
   


}


