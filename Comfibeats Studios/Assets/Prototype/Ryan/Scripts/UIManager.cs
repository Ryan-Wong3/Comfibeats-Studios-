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


    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        
    }

    public void DisplayUIScore()
    {
        //Setactive the screen 
        endScreen.gameObject.SetActive(true);

        //setting text for perfect
        perfectText.text = EndScreen.getPerfectScore().ToString();

        //set the rest of the player score reuslts to the end screen
        
        

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
