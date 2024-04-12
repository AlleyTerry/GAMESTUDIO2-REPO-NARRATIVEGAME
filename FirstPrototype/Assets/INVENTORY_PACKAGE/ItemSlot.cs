using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;



public class ItemSlot : MonoBehaviour 
{
    
    public static ItemSlot instance;
    public Image imageIcon;
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI descriptionBox;
    public GameObject nameButton;
  
    
    //we are going to itterate through this list to see if a slot is empyt

    ItemsNew stats = null;
    public bool isFull;

    public void TestDebug()
    {
        Debug.Log("hey this is the ItemSlot script.");
    }

    public void addItem(ItemsNew item)
    {
        stats = item;
        isFull = true;
        Debug.Log("this is stats var: " + stats);
        stats.UpdateStats(this);
        
        

    }
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // inventory = FindObjectOfType<Inventory>();

        //textBox = GetComponentInChildren<TextMeshProUGUI>();

       // verb = FindObjectOfType<Verb>();
       // target = FindObjectOfType<Target>();
    }

    

   


    

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
