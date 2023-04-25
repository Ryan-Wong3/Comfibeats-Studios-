using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Score playerScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUIScore()
    {
        //Update the UI to the new score 
    }

    private void OnEnable()
    {
        Actions.ScoreUIUpdate += UpdateUIScore;
    }

    private void OnDisable()
    {
        Actions.ScoreUIUpdate -= UpdateUIScore;
    }

}
