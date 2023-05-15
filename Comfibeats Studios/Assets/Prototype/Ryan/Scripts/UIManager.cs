    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Score UI")]
    [SerializeField]
    private Slider scoreSlider;

    [Header("Endscreen")]
    [SerializeField]
    private GameObject endScreen;
    [SerializeField]
    private TMP_Text perfectText;
    [SerializeField]
    private TMP_Text earlyText;
    [SerializeField]
    private TMP_Text lateText;
    [SerializeField]
    private TMP_Text missText;
    [SerializeField]
    private string SceneName;

    private void Update()
    {
        //to be deleted
        if (Input.GetKey(KeyCode.D))
        {
            //call the function to callEndScreen
            Actions.DisplayEndScreen();
        }

    }
    
    public void UpdateScoreUI(int i)
    {//get score and update the score slider
        scoreSlider.value = i;
    }

    public void DisplayEndScreen()
    {
        //Setactive the screen 
        endScreen.gameObject.SetActive(true);

        //setting text for perfect
        perfectText.text = "Perfect: " + EndScreen.getPerfectScore().ToString();
        earlyText.text = "Early: " + EndScreen.getEarlyScore().ToString();
        lateText.text = "Late: " + EndScreen.getLateScore();
        missText.text = "Miss: " + EndScreen.getMissScore();
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

    private void UpdateMissScore()
    {
        EndScreen.setMissScore(1);
    }

    private void OnEnable()
    {
        Actions.ScoreUIUpdate += UpdateScoreUI;
        Actions.DisplayEndScreen += DisplayEndScreen;
        Actions.PerfectUI += UpdatePerfectScore;
        Actions.EarlyUI += UpdateEarlyScore;
        Actions.LateUI += UpdateLateScore;
        Actions.MissUI += UpdateMissScore;
    }

    private void OnDisable()
    {
        Actions.ScoreUIUpdate -= UpdateScoreUI;
        Actions.DisplayEndScreen -= DisplayEndScreen;
        Actions.PerfectUI -= UpdatePerfectScore;
        Actions.EarlyUI -= UpdateEarlyScore;
        Actions.LateUI -= UpdateLateScore;
        Actions.MissUI -= UpdateMissScore;
    }

}
