using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text currentScoreText;
    public Text totalScoreText;
    public GameObject mobileButtonUI;
    
    public enum InfoType
    {
        Score,
        GameOver,
    };

    public InfoType type;

    void OnEnable()
    {
        switch (type)
        {
            case InfoType.GameOver:
            {
                currentScoreText.enabled = false;
                mobileButtonUI.SetActive(false);
                totalScoreText.text = String.Format("{0}", GameManager.Instance.score);
                break;
            }
        }
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Score:
            {
                currentScoreText.text = String.Format("Score : {0}", GameManager.Instance.score);
                break;
            }
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene("PlayScene");
        Time.timeScale = 1;
    }
}
