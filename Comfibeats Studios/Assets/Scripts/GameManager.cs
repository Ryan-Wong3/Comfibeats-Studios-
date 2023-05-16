using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    //Set key to press
    public KeyCode keyToPress;
    public bool hasStarted = false;

    public float bpm;
    [Header("for calculation purpose do not touch")]
    public float noteInterval;

    //for music 
    public AudioSource audioSource;
    public float songLength;

    public int flashCounter = 0;

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

        hasStarted = true; //track gamestate

        noteInterval = 60f / bpm;
        
        audioSource = GetComponent<AudioSource>();
        songLength = audioSource.clip.length;
        audioSource.Play();
    }

}
