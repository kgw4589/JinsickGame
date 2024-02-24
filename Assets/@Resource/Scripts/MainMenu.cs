using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public GameObject gameInformationObject;
    
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameInformation()
    {
        gameInformationObject.SetActive(true);
    }

    public void InformationClose()
    {
        gameInformationObject.SetActive(false);
    }

    public void End()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 
    }

}
