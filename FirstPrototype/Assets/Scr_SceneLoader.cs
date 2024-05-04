using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_SceneLoader : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("PersistentScene");
        ///SceneManager.UnloadSceneAsync("TitleScreen"); Not needed so long as we onyl use this function to start a new game from the main menu. Logic for load will probably need to be reworked.
    }

}
