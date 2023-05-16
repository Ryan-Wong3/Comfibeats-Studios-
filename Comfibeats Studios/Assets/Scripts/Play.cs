using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public void LevelSelect()
    {
        SceneManager.LoadScene("level select");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("main menu");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Gameplay2");
    }

    public void Level2()
    {
        SceneManager.LoadScene("DarkMode");
    }
}
