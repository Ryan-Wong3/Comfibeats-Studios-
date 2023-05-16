using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.Instance.audioSource.Pause();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameManager.Instance.audioSource.Play();
    }
}
