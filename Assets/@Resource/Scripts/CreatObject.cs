using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CreatObject : MonoBehaviour
{
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputDrop = false;
    
    public float moveSpeed = 4;
    public GameObject currentObj;
    private float _leftRange = -3.1f;
    private float _rightRange = 3f;
    private bool _isReady = false;

    private int _earlyStateIndex;
    private int[] _earlyState = { 0, 0, 1, 0, 0, 0, 2, 0, 0, 1, 2, 1, 0 };

    void Start()
    {
        _earlyStateIndex = 0;
        StartCoroutine(ObjectSetting(0));
    }
    
    void Update()
    {
        Move();
        Drop();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector2(h, 0).normalized;
        if (transform.position.x < _leftRange)
        {
            transform.position = new Vector2(_leftRange, transform.position.y);
        }
        else if (transform.position.x > _rightRange)
        {
            transform.position = new Vector2(_rightRange, transform.position.y);
        }
        else
        {
            transform.position += dir * (moveSpeed * Time.deltaTime);
        }
        
        if (inputLeft && !inputRight)
        {
            dir = new Vector2(-1, 0).normalized;
            transform.position += dir * (moveSpeed * Time.deltaTime);
        }
        if (!inputLeft && inputRight)
        {
            dir = new Vector2(1, 0).normalized;
            transform.position += dir * (moveSpeed * Time.deltaTime);
        }
    }

    void Drop()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || inputDrop) && currentObj != null && _isReady)
        {
            var transformPosition = currentObj.transform.position;
            transformPosition.z += 1; 
            currentObj.transform.SetParent(null);
            currentObj.GetComponent<Rigidbody2D>().gravityScale = 1;
            currentObj.GetComponent<Collider2D>().enabled = true;
            currentObj = null;
            _isReady = false;

            StartCoroutine(ObjectSetting(2.0f));
        }
    }

    IEnumerator ObjectSetting(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (currentObj == null)
        {
            List<GameObject> mainObjectList = GameManager.Instance.mainObjectList;
            if (_earlyStateIndex < _earlyState.Length)
            {
                currentObj = Instantiate(mainObjectList[_earlyState[_earlyStateIndex]], transform);
                _earlyStateIndex++;
            }
            else
            {
                currentObj = Instantiate(mainObjectList[Random.Range(0, 5)], transform);
            }
            currentObj.GetComponent<Rigidbody2D>().gravityScale = 0;
            currentObj.GetComponent<Collider2D>().enabled = false;
            currentObj.transform.position = transform.position;
            _isReady = true;
            inputDrop = false;
        }
    }
}