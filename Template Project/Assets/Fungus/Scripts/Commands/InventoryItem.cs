
using UnityEngine;

//THIS BELONGS IN THE FUNGUS > SCRIPTS > COMMANDS FOLDER 


[CreateAssetMenu(menuName = "New InvenotryItem", order = 1)]
public class InventoryItem : ScriptableObject
{
    public bool itemOwned = false;

    public string itemName;
    public Sprite itemIcon;

    public bool combinable;
    public InventoryItem[] combinableItem;
    public string[] successBlockName;
    public string failBlockName;
}
