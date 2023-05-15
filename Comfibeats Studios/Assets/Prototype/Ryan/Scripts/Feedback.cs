using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Feedback : MonoBehaviour
{
    [SerializeField]
    private TMP_Text feedbackText;

    public IEnumerator PerfectFeedback()
    {
        feedbackText.text = "Perfect";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }

    public IEnumerator EarlyFeedback() 
    {
        feedbackText.text = "Early";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }

    public IEnumerator LateFeedback()
    {
        feedbackText.text = "Late";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }

    public IEnumerator MissFeedback()
    {
        feedbackText.text = "Miss";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }
}
