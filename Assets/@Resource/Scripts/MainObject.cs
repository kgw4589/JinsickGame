using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    private bool _isChange = false;
    
    public enum ObjInfo
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Ninth,
        Tenth,
        Final
    };

    public ObjInfo currentInfo;
    
    private Rigidbody2D _myRigid;

    void Start()
    {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MainObject"))
        {
            MainObject obj = collision.gameObject.GetComponent<MainObject>();
            
            bool isSameInfo = currentInfo == obj.currentInfo;
            bool isInfoIsNotFinal = currentInfo != ObjInfo.Final;
            bool isChanging = _isChange || obj._isChange;
            
            if (isSameInfo && isInfoIsNotFinal && !isChanging)
            {
                _isChange = true;
                obj._isChange = true;
                Vector2 midPos = (transform.position + obj.transform.position) / 2;
                transform.position = midPos;
                if (gameObject.activeSelf)
                {
                    GameManager gameManager = GameManager.Instance;
                    gameManager.audioSource.clip = gameManager.mergeClip;
                    gameManager.audioSource.Play();
                    
                    obj.gameObject.SetActive(false);
                    ChangeNextInfo(midPos);
                    Destroy(obj);
                }
            }
        }
    }

    public void ChangeNextInfo(Vector2 midPos)
    {
        List<GameObject> mainObjectList = GameManager.Instance.mainObjectList;
        int index = 0;
        switch (currentInfo)
        {
            case ObjInfo.First:
            {
                index = 1;
                GameManager.Instance.CalculationScore(10);
                break;
            }
            case ObjInfo.Second:
            {
                index = 2;
                GameManager.Instance.CalculationScore(20);
                break;
            }
            case ObjInfo.Third:
            {
                index = 3;
                GameManager.Instance.CalculationScore(40);
                break;
            }
            case ObjInfo.Fourth:
            {
                index = 4;
                GameManager.Instance.CalculationScore(80);
                break;
            }
            case ObjInfo.Fifth:
            {
                index = 5;
                GameManager.Instance.CalculationScore(160);
                break;
            }
            case ObjInfo.Sixth:
            {
                index = 6;
                GameManager.Instance.CalculationScore(320);
                break;
            }
            case ObjInfo.Seventh:
            {
                index = 7;
                GameManager.Instance.CalculationScore(640);
                break;
            }
            case ObjInfo.Eighth:
            {
                index = 8;
                GameManager.Instance.CalculationScore(1280);
                break;
            }
            case ObjInfo.Ninth:
            {
                index = 9;
                GameManager.Instance.CalculationScore(2560);
                break;
            }
            case ObjInfo.Tenth:
            {
                index = 10;
                GameManager.Instance.CalculationScore(5120);
                break;
            }
        }
        Destroy(gameObject);
        GameObject obj = Instantiate(mainObjectList[index]);
        Rigidbody2D objRigid = GetComponent<Rigidbody2D>();
        obj.transform.position = midPos;
        objRigid.velocity = Vector2.zero;
    }
}