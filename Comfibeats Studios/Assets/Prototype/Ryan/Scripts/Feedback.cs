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
        //Debug.Log("Perfect Feedback");
        //turn on perfect text
        feedbackText.text = "Perfect";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }

    public IEnumerator EarlyFeedback() 
    {
        //Debug.Log("Early");
        //turn on perfect text
        feedbackText.text = "Early";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }

    public IEnumerator LateFeedback()
    {
        //Debug.Log("Late");
        //turn on perfect text
        feedbackText.text = "Late";
        yield return new WaitForSeconds(1.5f);
        feedbackText.text = "";
    }
}
