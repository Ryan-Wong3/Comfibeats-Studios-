using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
<<<<<<< Updated upstream
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
=======
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
>>>>>>> Stashed changes
    {
        Time.timeScale = 1;
    }
}
