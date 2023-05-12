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

}
