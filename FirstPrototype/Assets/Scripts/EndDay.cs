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

    public void EndDayButton()
    {
        SceneManager.LoadScene("Day2Test");
        MainFlowChart.ExecuteBlock("Day2START");

    }
}
