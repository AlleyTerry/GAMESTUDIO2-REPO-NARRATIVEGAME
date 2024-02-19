using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class Inventory : MonoBehaviour
{
    //we are creating list variables to hold all of the items we need to be able to turn off and on
    private MenuDialog[] menuDialogs;
    private SayDialog[] SayDialogs;
    public CanvasGroup canvasGroup;
    
    //private target target
    //this was from the tutorial used to pause the player character our game is in first person so no need
    
    //references to other scripts not yet made
    public InventoryItem[] inventoryItems;
    public ItemSlot[] itemSlots;


    private Flowchart[] flowchats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //finding all of the items of this type
        menuDialogs = FindObjectsOfType<MenuDialog>();
        SayDialogs = FindObjectsOfType<SayDialog>();
        //target = FindObjectOfType<Target>();
        flowchats = FindObjectsOfType<Flowchart>();

    }

    // Update is called once per frame
    void Update()
    {
        //if you press the "inventory" button (made in editor preferences input system) the inventory will pop up
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventory(!canvasGroup.interactable);
        }
    }
    
    //inventory toggle function turns everything off and turns inventory on
    private void ToggleInventory(bool setting)
    {
        ToggleCanvasGroup(canvasGroup, setting);
        InitializeItemSlots();
        
        //from the tutorial, this stops the player if a cutscene is happening
        //if (!GraphicsBuffer.Target.cutSceneInProgress)
        //{
           // target.inDialog = setting;
        //}

        foreach (MenuDialog menuDialog in menuDialogs)
        {
            ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);
        }

        foreach (SayDialog sayDialog in SayDialogs)
        {
            //REMEMBER TO GO INTO THE SAY DIALOG SCRIPT AND ADD THE DIALOGENABLED VARIABLE
            //allows you to open inventory during dialog and then return to it
            sayDialog.dialogEnabled = !setting;
            if (setting)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            
            ToggleCanvasGroup(sayDialog.GetComponent<CanvasGroup>(), !setting);
        }
        
    }

    public void InitializeItemSlots()
    {
        //whenever we open or close the inventory it will referesh the items to see if we have new ones or gotten rid of ones
        //calling the list of the items that we ownfrom the InventoryItem Script (not yet made)
        List<InventoryItem> ownedItems = GetOwnedItems(inventoryItems.ToList());
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < ownedItems.Count)
            {
                itemSlots[i].DisplayItem(ownedItems[i]);
            }
            else
            {
                itemSlots[i].ClearItem();
            }
        }
    }

    public List<InventoryItem> GetOwnedItems(List<InventoryItem> inventoryItems)
    {
        List<InventoryItem> ownedItems = new List<InventoryItem>();
        foreach (InventoryItem item in inventoryItems)
        {
            if (item.itemOwned)
            {
                ownedItems.Add(item);
            }
        }

        return ownedItems;
    }
    
    
    

    private void ToggleCanvasGroup(CanvasGroup canvasGroup, bool setting)
    {
        //these are all of the aspects of the component that we are turning off or on
        canvasGroup.alpha = setting ? 1f : 0f;
        canvasGroup.interactable = setting;
        canvasGroup.blocksRaycasts = setting;
    }
    
}
