using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZoneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.Instance.keyToPress))
        {
            Debug.Log(GameManager.Instance.keyToPress.ToString() + " pressed down");
        }

        if(Input.GetKeyUp(GameManager.Instance.keyToPress))
        {
            Debug.Log(GameManager.Instance.keyToPress.ToString() + " pressed up");

        }
    }
}
