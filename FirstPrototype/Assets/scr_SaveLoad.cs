using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_SaveLoad : MonoBehaviour
{
    // Make string variable that holds the name of the current block
    // Get name of current block
    // Save to string block
    // Execute block using string name in code
    public Fungus.Flowchart MFlowchart;
    public SaveFile save = new SaveFile();
    public string openBlock;
    public pause_script p_script;
    public GameObject cam;
    public Scene currentScene;
    //public string SavedBlock;
    //public bool D1TryDoor, D1Wait, D1Coach,
    //    D1Neighbor, D1Promise, 
    //    NothingDuke, ChoseDuke, FlowersGot;
    //public int Trust, Attachment, Love, Regard;

    private void Start()
    {
        p_script = gameObject.GetComponent<pause_script>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void FixedUpdate()
    {
        openBlock = MFlowchart.SelectedBlock.BlockName;
        currentScene = SceneManager.GetActiveScene();
        if (Input.GetKey(KeyCode.O))
        {
            DisplayCurrentScene();
        }
    }

    private void DisplayCurrentScene()
    {
        Debug.Log(currentScene.name);
    }

    public void SaveGame()
    {
        save.SavedBlock = openBlock;
        save.SavedCamPosX = cam.transform.position.x;
        save.SavedCamPosY = cam.transform.position.y;
        save.SavedCamPosZ = cam.transform.position.z;

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
        if(p_script.pause == true) { p_script.ResumeGame(); }
        MFlowchart.StopAllBlocks();
        GameObject OpenMenu = GameObject.FindWithTag("Choice Menu");
        Destroy(OpenMenu);
        LoadFromJson();

        //Go to the saved block. Moved above int and bool loads to try and get rid of the 'double dip stat buff' bug
        MFlowchart.ExecuteBlock(save.SavedBlock);
        cam.transform.transform.position = new Vector3(save.SavedCamPosX, save.SavedCamPosY, save.SavedCamPosZ);
        
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
    }
}
[System.Serializable]
public class SaveFile
{
    public string SavedBlock;
    public float SavedCamPosX, SavedCamPosY, SavedCamPosZ;
    public bool D1TryDoor, D1Wait, D1Coach,
      D1Neighbors, D1Promise,
      NothingDuke, ChoseDuke, FlowersGot;
    public int Trust, Attachment, Love, Regard;
}