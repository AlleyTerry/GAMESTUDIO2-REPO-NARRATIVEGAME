using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DialogueDisable : MonoBehaviour
{
    //public GameObject UI;
    //public GameObject UI_Dialogue;
    //public GameObject UI_Menu;
    public GameObject[] buttons;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //UI = GameObject.FindGameObjectWithTag("Dialogue");
    //}
    private void OnEnable()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }
    private void OnDisable()
    {
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(true);
            }
        }
    }

        // Update is called once per frame
        void Update()
        {
        foreach (GameObject button in buttons)
        {
             button.SetActive(false);
        }
        //    UI = GameObject.FindGameObjectWithTag("Dialogue");
        //    if (UI == null)
        //    {
        //        print("NULL");
        //    }
        //    if (UI.activeSelf) 
        //    {   foreach (GameObject button in buttons)
        //        {
        //            button.SetActive(false);
        //        }
        //    }
        //    else if (UI == null) 
        //    {
        //        foreach (GameObject button in buttons)
        //        {
        //            button.SetActive(true);
        //        }
        //    }
    }
    }
