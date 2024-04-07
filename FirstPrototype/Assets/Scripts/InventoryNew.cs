using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fungus;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.UI;
using Fungus;
using Unity.VisualScripting;
using Fungus;

public class InventoryNew : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    public static ItemSlot holderFunction = new ItemSlot();
    public Fungus.Flowchart MainFlowchart;
    public ScriptableObject itemToAdd;


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
        itemToAdd = Instantiate(Resources.Load<ScriptableObject>(newPath));
        Debug.Log(itemToAdd);
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Debug.Log(itemSlots[i].name);
            if (itemSlots[i].isFull == false)
            {
                Debug.Log("hey the first part is working");
                holderFunction.TestDebug();
                holderFunction.addItem((ItemsNew)itemToAdd);
                
                break;
            }
            else
            {
                return;
            }
            break;
        }
    }


   

    
}
