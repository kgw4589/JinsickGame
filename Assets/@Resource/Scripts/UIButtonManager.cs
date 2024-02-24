using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public CreatObject creatObject;

    public void LeftUp()
    {
        creatObject.inputLeft = false;
    }
    public void LeftDown()
    {
        creatObject.inputLeft = true;
    }

    public void RightUp()
    {
        creatObject.inputRight = false;
    }
    public void RightDown()
    {
        creatObject.inputRight = true;
    }

    public void DropDown()
    {
        creatObject.inputDrop = true;
    }

    public void Reset()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
