using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
{
    public Fungus.Flowchart myFlowchart;
    public string currentItem = "";
    public InventoryItem item;
    private Inventory inventory;

    public Image image;
    private TextMeshProUGUI textBox;

    //about player movement
    //private Verb verb;
    //private Target target;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        textBox = GetComponentInChildren<TextMeshProUGUI>();

       // verb = FindObjectOfType<Verb>();
       // target = FindObjectOfType<Target>();
    }

    public void DisplayItem(InventoryItem thisItem)
    {
        item = thisItem;
        textBox.text = item.itemName;
        image.sprite = item.itemIcon;
        gameObject.SetActive(true);
    }

    public void ClearItem()
    {
        item = null;
        image.sprite = null;
        gameObject.SetActive(false);
    }


    public void CurrentItemName()
    {
        currentItem = item.itemName;
        myFlowchart.SetStringVariable("CurrentItem", currentItem);
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
