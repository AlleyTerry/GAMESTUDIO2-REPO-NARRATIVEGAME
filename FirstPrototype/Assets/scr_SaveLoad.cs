using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SaveLoad : MonoBehaviour
{
    // Make string variable that holds the name of the current block
    // Get name of current block
    // Save to string block
    // Execute block using string name in code
    public Fungus.Flowchart MFlowchart;
    public SaveFile save = new SaveFile();
    public string openBlock;
    //public string SavedBlock;
    //public bool D1TryDoor, D1Wait, D1Coach,
    //    D1Neighbor, D1Promise, 
    //    NothingDuke, ChoseDuke, FlowersGot;
    //public int Trust, Attachment, Love, Regard;


    private void FixedUpdate()
    {
        openBlock = MFlowchart.SelectedBlock.BlockName;
    }

    public void SaveGame()
    {
        save.SavedBlock = openBlock;

        save.D1TryDoor = MFlowchart.GetBooleanVariable("D1TryDoor");
        save.D1Wait = MFlowchart.GetBooleanVariable("D1Wait");
        save.D1Coach = MFlowchart.GetBooleanVariable("D1Coach");
        save.D1Neighbors = MFlowchart.GetBooleanVariable("D1Neighbors");
        save.D1Promise = MFlowchart.GetBooleanVariable("D1Promise");
        save.NothingDuke = MFlowchart.GetBooleanVariable("NothingDuke");
        save.ChoseDuke = MFlowchart.GetBooleanVariable("ChoseDuke");
        save.FlowersGot = MFlowchart.GetBooleanVariable("FlowersGot");

        save.Trust = MFlowchart.GetIntegerVariable("Trust");
        save.Attachment = MFlowchart.GetIntegerVariable("Attachment");
        save.Love = MFlowchart.GetIntegerVariable("Love");
        save.Regard = MFlowchart.GetIntegerVariable("Regard");

        string JsonData = JsonUtility.ToJson(save);
        string filePath = Application.persistentDataPath + "/JsonData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, JsonData);
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/JsonData.json";
        string JsonData = System.IO.File.ReadAllText(filePath);
        save = JsonUtility.FromJson<SaveFile>(JsonData);
    }

    public void LoadGame()
    {
        MFlowchart.StopAllBlocks();
        GameObject OpenMenu = GameObject.FindWithTag("Choice Menu");
        Destroy(OpenMenu);
        LoadFromJson();

        //Load all the bools
        MFlowchart.SetBooleanVariable("D1TryDoor", save.D1TryDoor);
        MFlowchart.SetBooleanVariable("D1Wait", save.D1Wait);
        MFlowchart.SetBooleanVariable("D1Coach", save.D1Coach);
        MFlowchart.SetBooleanVariable("D1Neighbors", save.D1Neighbors);
        MFlowchart.SetBooleanVariable("D1Promise", save.D1Promise);
        MFlowchart.SetBooleanVariable("NothingDuke", save.NothingDuke);
        MFlowchart.SetBooleanVariable("ChoseDuke", save.ChoseDuke);
        MFlowchart.SetBooleanVariable("FlowersGot", save.FlowersGot);
        //Load all the ints
        MFlowchart.SetIntegerVariable("Trust", save.Trust);
        MFlowchart.SetIntegerVariable("Attachment", save.Attachment);
        MFlowchart.SetIntegerVariable("Love", save.Love);
        MFlowchart.SetIntegerVariable("Regard", save.Regard);
        //Go to the saved block
        MFlowchart.ExecuteBlock(save.SavedBlock);
    }
}
[System.Serializable]
public class SaveFile
{
    public string SavedBlock;
    public bool D1TryDoor, D1Wait, D1Coach,
      D1Neighbors, D1Promise,
      NothingDuke, ChoseDuke, FlowersGot;
    public int Trust, Attachment, Love, Regard;
}