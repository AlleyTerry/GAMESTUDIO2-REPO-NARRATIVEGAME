using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ItemSlot : MonoBehaviour 
{
    
   
    

    public Image imageIcon;
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI descriptionBox;
    public static ItemSlot instance;
    
    
    
    
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
