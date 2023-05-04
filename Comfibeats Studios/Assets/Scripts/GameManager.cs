using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    //Set key to press
    public KeyCode keyToPress;
    public bool hasStarted;

    public float bpm;
    public float noteInterval;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        hasStarted = false; //track gamestate

        noteInterval = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)      //possible change to specific key or button to start game
            {
                hasStarted = true;
            }
        }
    }
}
