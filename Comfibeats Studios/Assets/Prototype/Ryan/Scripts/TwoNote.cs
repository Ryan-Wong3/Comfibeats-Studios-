using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoNote : MonoBehaviour
{
    [SerializeField]
    private Note noteLeft;
    [SerializeField]
    private Note noteRight;

    /*
    [SerializeField]
    private GameObject tracker;
    [SerializeField]
    private GameObject trackerRightPos;
    */

    private bool leftFlashed = false;
    private bool swap = false;

    // Start is called before the first frame update
    void Start()
    {
        //tracker = GameObject.FindGameObjectWithTag("Tracker");
    }

    // Update is called once per frame
    void Update()
    {

        if (noteLeft.getFlashCheck() == true && leftFlashed == false)
        {
            leftFlashed = true;
            //disable the right script 
            noteRight.enabled = !noteRight.enabled;
        }

        if (noteLeft.GetIsFinished() == true && swap == false )
        {
            swap = true;
            //disable the left
            noteLeft.enabled = !noteLeft.enabled;
            //enable the right 
            noteRight.enabled = !noteRight.enabled;

            //tracker.transform.position= trackerRightPos.transform.position  ;
        }

        


    }
}
