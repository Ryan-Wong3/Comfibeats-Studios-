using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Song : MonoBehaviour
{
    public AudioSource song;
    public float timer;
    bool songStarted = false;

    private void Start()
    {
        song.playOnAwake = false;
    }
    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance.hasStarted)
        {
            song.Play();
            songStarted = true;
        }

        if(songStarted)
            timer += Time.deltaTime;


        if (timer > song.clip.length)
        {
            Debug.Log("Working");
            Actions.DisplayEndScreen();
        }
    }
}
