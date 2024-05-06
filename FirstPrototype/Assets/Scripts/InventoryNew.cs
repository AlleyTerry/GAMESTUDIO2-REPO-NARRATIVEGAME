using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fungus;
using TMPro;
using UnityEngine.UI;
using Fungus;
using Unity.VisualScripting;
using Fungus;

public class InventoryNew : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    public Fungus.Flowchart MainFlowchart;
    public ItemsNew itemToAdd;


    public void ListGoThrough()
    {
        StringVariable currentItemStringVar = MainFlowchart.GetVariable("CurrentItem") as StringVariable;
        //currentItemStringVar.Value = currentItemString;
        Debug.Log(currentItemStringVar + "is the current item being held");
        
        
        //setting a variable from the flowchart in code
        //BooleanVariable boolVar = MainFlowchart.GetVariable("MyBool") as BooleanVariable; 
        //boolVar.Value = false;
        string newPath = "Prefabs/Items/" + currentItemStringVar;
        Debug.Log(newPath);
        if (currentItemStringVar != null)
        {
            itemToAdd = (ItemsNew)Instantiate(Resources.Load<ScriptableObject>(newPath));
            Debug.Log(itemToAdd);
            for (int i = 0; i < itemSlots.Length; i++)
            {
                Debug.Log(itemSlots[i].name);
                if (itemSlots[i].isFull == false && itemSlots[i].tag == itemToAdd.itemName)
                {
                    itemSlots[i].nameButton.gameObject.SetActive(true);
                    Debug.Log("hey the first part is working");
                    itemSlots[i].TestDebug();
                    itemSlots[i].addItem(itemToAdd);
                    break;
                }
            
            
            }
        }
        
    }

    public void RemoveItem()
    {
        StringVariable currentItemStringVar = MainFlowchart.GetVariable("CurrentItem") as StringVariable;
        //currentItemStringVar.Value = currentItemString;
        Debug.Log(currentItemStringVar + "is the current item being held");
        
        
        //setting a variable from the flowchart in code
        //BooleanVariable boolVar = MainFlowchart.GetVariable("MyBool") as BooleanVariable; 
        //boolVar.Value = false;
        string newPath = "Prefabs/Items/" + currentItemStringVar;
        Debug.Log(newPath);
        itemToAdd = (ItemsNew)Instantiate(Resources.Load<ScriptableObject>(newPath));
        Debug.Log(itemToAdd);
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Debug.Log(itemSlots[i].name);
            if (itemSlots[i].isFull == true && itemSlots[i].tag == itemToAdd.itemName)
            {
                itemSlots[i].nameButton.gameObject.SetActive(false);
                Debug.Log("hey the first part is working");
                itemSlots[i].TestDebug();
                itemSlots[i].gameObject.SetActive(false);
                break;
            }
            
            
        }
    }

   

    
}
