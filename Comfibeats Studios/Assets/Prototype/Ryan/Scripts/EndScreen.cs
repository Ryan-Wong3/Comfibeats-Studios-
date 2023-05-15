using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EndScreen 
{
    [SerializeField]
    private static  int perfect;
    [SerializeField]
    private static int early;
    [SerializeField]
    private static int late;
    [SerializeField]
    private static int miss;
    

    //sets the score for the endscreen
    public static void setPerfectScore(int i)
    {
        perfect += i;
    }

    public static void setEarlyScore(int i)
    {
        early += i;
    }

    public static void setLateScore(int i)
    {
        late += i;
    }

    public static void setMissScore(int i)
    {
        miss += i;
    }

    public static int getPerfectScore()
    {
        return perfect;
    }

    public static int getEarlyScore()
    {
        return early;
    }

    public static int getLateScore()
    {
        return late;
    }

    public static int getMissScore()
    {
        return miss;
    }

    /*
    public static string getEndMessage()
    {
        if()
        return;
    }
    */
}
