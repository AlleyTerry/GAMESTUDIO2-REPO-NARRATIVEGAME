using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class EndDay : MonoBehaviour
{
    public Fungus.Flowchart MainFlowChart;
    //set enmum days
    //make switch statement and cases for ending each day
    public static EndDay instance;

    public GameObject persistentObjects;
    

    public enum Days
    {
        Day1Test,
        Day2Test,
        Day3Test,
        Day4Test,
        Day5Test
    }

    public Days CurrentDay = Days.Day1Test;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.LoadScene("Day1Test", LoadSceneMode.Additive);
    }

    public void EndDayButton()
    {
        switch (CurrentDay)
        {
            case Days.Day1Test:
                SceneManager.LoadScene("Day2Test");
                MainFlowChart.ExecuteBlock("Day2START");
                break;
            case Days.Day2Test:
                SceneManager.LoadScene("Day3Test");
                MainFlowChart.ExecuteBlock("Day3START");
                break;
            case Days.Day3Test:
                SceneManager.LoadScene("Day4Test");
                MainFlowChart.ExecuteBlock("Day4START");
                break;
            case Days.Day4Test:
                SceneManager.LoadScene("Day5Test");
                MainFlowChart.ExecuteBlock("Day5START");
                break;
        }

     

    }
    public void DestroyAll()
    {
        SceneManager.LoadScene("TitleScreen");
        Destroy(persistentObjects);
        
    }


}
