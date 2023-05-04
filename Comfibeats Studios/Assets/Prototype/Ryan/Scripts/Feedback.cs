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
        Debug.Log("Perfect Feedback");
        //turn on perfect text
        feedbackText.text = "Perfect";
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        feedbackText.gameObject.SetActive(false);
    }

    public IEnumerator EarlyFeedback() 
    {
        //turn on early text
        Debug.Log("Early");
        //turn on perfect text
        feedbackText.text = "Early";
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        feedbackText.gameObject.SetActive(false);
    }

    public IEnumerator LateFeedback()
    {
        //turn on early text
        Debug.Log("Late");
        //turn on perfect text
        feedbackText.text = "Late";
        feedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        feedbackText.gameObject.SetActive(false);
    }

    /*
    private void OnEnable()
    {
        Actions.PerfectUI += PerfectFeedback;
        Actions.EarlyUI += EarlyFeedback;
        Actions.LateUI += LateFeedback;
    }

    private void OnDisable()
    {
        Actions.PerfectUI -= PerfectFeedback;
        Actions.EarlyUI -= EarlyFeedback;
        Actions.LateUI -= LateFeedback;
    }
    */

}
