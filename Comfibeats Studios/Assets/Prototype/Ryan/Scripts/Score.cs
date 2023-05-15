using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    [SerializeField]
    private int score;

    public void setScore(int i)
    {
        score += i;

        //Update UI;
        Actions.ScoreUIUpdate(score);

    }

    public int getScore()
    {
        return score;
    }

    private void OnEnable()
    {
        Actions.ScoreUpdate += setScore;
    }

    private void OnDisable()
    {
        Actions.ScoreUpdate -= setScore;
    }

}
