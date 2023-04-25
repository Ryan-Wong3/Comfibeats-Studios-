using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int score;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int s)
    {
        score = s;
    }
    public int getScore()
    {
        return score;
    }
}
