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
    [Header("for calculation purpose do not touch")]
    public float noteInterval;

    //for music 
    public AudioSource audioSource;

    public int flashCounter = 0;
    public int restCounter = 0;

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
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.GetKeyDown(keyToPress))      //possible change to specific key or button to start game
            {
                hasStarted = true;
                audioSource.Play();
            }
        }
    }

}
