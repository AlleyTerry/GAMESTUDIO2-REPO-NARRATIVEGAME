using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_script : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause) { ResumeGame(); }
            else if(!pause) { PauseGame(); }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
}
