using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField]
    private float noteTime;
    [SerializeField]
    private float perfectFrontTime;
    [SerializeField]
    private float perfectEndTime;

    [Header("Marker")]
    //Marker is the red background
    [SerializeField]
    private GameObject marker;
    //tracker is the moving icon above the note 
    [SerializeField]
    private GameObject tracker;
    private Vector2 trackerStartPos;

    [Header("Distance")]
    private float distance = 0;
    [SerializeField]
    private float breakingDistance = 0;

    [Header("Boolean Statement")]
    private bool startNote = false;
    private bool flashed = false;
    private bool earlyCheck = false;

    [Header("Slider")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float sliderSpeed;
    [SerializeField]
    private Image imageSlider;
    [SerializeField]
    private GameObject sliderBackground;

    [Header("Flash")]
    [SerializeField]
    private GameObject flash;

    [Header("Feedback UI")]
    [SerializeField]
    private Feedback feedback;

    private float timer;

    private void Awake()
    {
        feedback = GameObject.FindObjectOfType<Feedback>();
        marker = GameObject.FindGameObjectWithTag("Marker");
        tracker = GameObject.FindGameObjectWithTag("Tracker");
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = noteTime;

        //grab the starting position of the tracker 
        trackerStartPos = tracker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //distance check for flash
        distance = (marker.transform.position.y - transform.position.y);

        //Flashing 
        if (distance < breakingDistance && flashed == false)
        {
            //flash UI element
            StartCoroutine(Flash());
        }

        //If note has started
        if (startNote)
        {            
            timer += Time.deltaTime;

            /*
            //tracker
            float xPos = tracker.transform.position.x + Time.deltaTime / 1.5f;
            tracker.transform.position = new Vector3(xPos, tracker.transform.position.y, 0);
            */
            //reset the tracker position when not colliding

        }


        //Enable slider to move when collided with marker
        if (startNote && Input.GetKey(KeyCode.Space))
        {
            slider.value += (sliderSpeed * Time.deltaTime);
            //tracker
            float xPos = tracker.transform.position.x + Time.deltaTime * 8;
            tracker.transform.position = new Vector3(xPos, tracker.transform.position.y, 0);
        }

        //Debug - Delete or comment out when note is ready 
        if (slider.value == noteTime)
        {
            Debug.Log(timer);
        }

        //should be rewritten in future iteration (Short term solution)
        //Early - If note hasn't started and spacebar is press || note has started and spacebar is let go before perfectEndTime 
        if (!startNote && earlyCheck && Input.GetKeyDown(KeyCode.Space) || startNote && Input.GetKeyUp(KeyCode.Space) && timer < perfectEndTime)
        {
            StartCoroutine(feedback.EarlyFeedback());
            EndScreen.setEarlyScore(1);
        }
        //Perfect - pressing at start and letting go at the very end 
        else if (startNote && Input.GetKeyDown(KeyCode.Space) && (timer <= perfectFrontTime) || startNote && Input.GetKeyUp(KeyCode.Space) && (timer < noteTime) && (timer > perfectEndTime))
        {
            //end the note early if within the end range for perfect   
            if ((timer < noteTime) && (timer > perfectEndTime))
                startNote = false;

            StartCoroutine(feedback.PerfectFeedback());

            EndScreen.setPerfectScore(1);

        }  
        //Late - Timer is pass perfect front and perfect end || Timer is greater than note time
        else if (startNote && Input.GetKeyDown(KeyCode.Space) && timer > perfectFrontTime && timer < perfectEndTime || startNote && Input.GetKey(KeyCode.Space) && timer > noteTime  )
        {
            StartCoroutine(feedback.LateFeedback());
            EndScreen.setLateScore(1);
        }

        //If timer is greater than noteTime then the current note is set to false
        if (timer > noteTime)
            startNote = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Marker")
        {
            startNote = true;
            imageSlider.gameObject.SetActive(true);
        }
        else if(other.tag == "Early")
        {
            earlyCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Marker")
        {
            startNote = false;
            tracker.transform.position = trackerStartPos;
        }
    }

    IEnumerator Flash()
    {
        Debug.Log("Flash");
        flashed = true;
        flash.gameObject.SetActive(true);
        sliderBackground.SetActive(true);
        yield return new WaitForSeconds(.5f);
        flash.gameObject.SetActive(false);
    }
}
