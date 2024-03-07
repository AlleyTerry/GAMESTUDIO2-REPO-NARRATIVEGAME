using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_ScenePersistence : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W)) { SceneManager.LoadScene(1); };
    //    // For testing
    //}
}
