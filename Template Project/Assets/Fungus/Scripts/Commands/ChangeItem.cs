using UnityEngine;

namespace Fungus
{
    /// <summary>
    /// Plays a state of an animator according to the state name.
    /// </summary>
    [CommandInfo("Item",
        "Change Item",
        "adds or removes an item form the invenotry")]
    [AddComponentMenu("")]
    public class ChangeItem : Command
    {
        [Tooltip("Reference to an InventoryItem scriptable object that fills the ItemSlots in the Inventory")]
        [SerializeField] protected InventoryItem item;

        [Tooltip("Name of the state you want to play")] [SerializeField]
        protected bool add;



        public override void OnEnter()
        {
            if (item != null)
            {
                if (add)
                {
                    item.itemOwned = true;
                }
                else
                {
                    item.itemOwned = false;
                }
            }

            Continue();
        }

        public override string GetSummary()
        {
            if (item == null)
            {
                return "Error: No item selected";
            }

            return item.itemName;
        }

    }
}