using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Song : MonoBehaviour
{
    public float timer;
    bool songStarted = false;

    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance.hasStarted)
        {
            songStarted = true;
        }

        if(songStarted)
            timer += Time.deltaTime;


        if (timer > GameManager.Instance.songLength)
        {
            Debug.Log("SONG ENDED");
            Actions.DisplayEndScreen();
            GameManager.Instance.hasStarted = false;
        }
    }
}
