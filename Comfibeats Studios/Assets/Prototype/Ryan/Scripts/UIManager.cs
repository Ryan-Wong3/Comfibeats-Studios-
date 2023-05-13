    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /*
    [SerializeField]
    private Score playerScore;
    */

    [SerializeField]
    private GameObject endScreen;
    [SerializeField]
    private TMP_Text perfectText;
    [SerializeField]
    private TMP_Text earlyText;
    [SerializeField]
    private TMP_Text lateText;

    private void Update()
    {
        //to be deleted
        if (Input.GetKey(KeyCode.D))
        {
            //call the function to callEndScreen
            Actions.ScoreUIUpdate();
        }

    }
    public void DisplayUIScore()
    {
        //Setactive the screen 
        endScreen.gameObject.SetActive(true);

        //setting text for perfect
        perfectText.text = "Perfect Score: " + EndScreen.getPerfectScore().ToString();
        earlyText.text = "Early Score: " + EndScreen.getEarlyScore().ToString();
        lateText.text = "Late Score: " + EndScreen.getLateScore();
    }

    private void UpdatePerfectScore()
    {
        EndScreen.setPerfectScore(1);
    }

    private void UpdateEarlyScore()
    {
        EndScreen.setEarlyScore(1);
    }

    private void UpdateLateScore()
    {
        EndScreen.setLateScore(1);
    }

    private void OnEnable()
    {
        Actions.ScoreUIUpdate += DisplayUIScore;
        Actions.PerfectUI += UpdatePerfectScore;
        Actions.EarlyUI += UpdateEarlyScore;
        Actions.LateUI += UpdateLateScore;
    }

    private void OnDisable()
    {
        Actions.ScoreUIUpdate -= DisplayUIScore;
        Actions.PerfectUI -= UpdatePerfectScore;
        Actions.EarlyUI -= UpdateEarlyScore;
        Actions.LateUI -= UpdateLateScore;
    }

}
