using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    //UI
    public static Action DisplayEndScreen, PerfectUI, EarlyUI, LateUI, MissUI;
    public static Action<int> ScoreUpdate, ScoreUIUpdate;
    public static Action<Coroutine> feedbackUI;
   
}
