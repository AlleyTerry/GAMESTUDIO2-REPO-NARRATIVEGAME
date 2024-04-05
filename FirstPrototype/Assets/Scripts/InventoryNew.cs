using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor.VersionControl;

public class InventoryNew : MonoBehaviour
{
    public Fungus.Flowchart MainFlowchart;
    //we are going to itterate through this list to see if a slot is empyt
    public ItemSlot[] itemSlots;
    public string currentItemString;
    public ScriptableObject itemToAdd;
    public GameObject myInventory;
    

    private void Start()
    {
       
    }


    public void addItem()
    {
        
        StringVariable currentItemStringVar = MainFlowchart.GetVariable("CurrentItem") as StringVariable;
        //currentItemStringVar.Value = currentItemString;
        Debug.Log(currentItemStringVar + "is the current item being held");
        
        //setting a variable from the flowchar in code
        //BooleanVariable boolVar = MainFlowchart.GetVariable("MyBool") as BooleanVariable; 
        //boolVar.Value = false;
        string newPath = "Prefabs/Items/" + currentItemStringVar;
        Debug.Log(newPath);
        itemToAdd = Instantiate(Resources.Load<ScriptableObject>(newPath));

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == null)
            {
                ItemsNew.instance.UpdateStats(itemToAdd);
                break;
            }
            else
            {
                return;
            }
        }
       
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            myInventory.SetActive(true);
        }
    }
}
