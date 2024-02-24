using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int score = 0;
    public List<GameObject> mainObjectList = new List<GameObject>();
    public AudioSource audioSource;
    public AudioClip mergeClip;
    public AudioClip gameOverClip;

    private void Awake()
    {
        Instance = this;
    }
    
    public void CalculationScore(int getScore)
    {
        score += getScore;
    }
}
