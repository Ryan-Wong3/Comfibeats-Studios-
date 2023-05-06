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

    [SerializeField]
    private float earlyTime;
    [SerializeField]
    private float lateTime;
    [SerializeField]
    private float padding;


    [Header("Marker")]
    [SerializeField]
    private GameObject marker;
    [SerializeField]
    private GameObject tracker;


    [Header("Distance")]
    [SerializeField]
    private float distance = 0;
    [SerializeField]
    private float breakingDistance = 0;


    [Header("Boolean Statement (Remove)")]
    [SerializeField]
    private bool start = false;
    private bool flashed = false;
    private bool spacebarHeld = false;

    [Header("Slider")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float sliderSpeed;
    [SerializeField]
    private Image imageSlider;

    [Header("Flash")]
    [SerializeField]
    private GameObject flash;

    [Header("Note Start/End")]
    [SerializeField]
    private GameObject front;
    [SerializeField]
    private GameObject end;

    [Header("Feedback UI")]
    [SerializeField]
    private Feedback feedback;


    private float timer;
    private float seconds;

    private void Awake()
    {
        feedback = GameObject.FindObjectOfType<Feedback>();
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = noteTime;   
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

        if (start)
        {
            timer += Time.deltaTime;
            seconds = timer % 60;

            float xPos = tracker.transform.position.x + Time.deltaTime/1.5f;
            tracker.transform.position = new Vector3(xPos, tracker.transform.position.y, 0);


        }

        
        //Enable slider to move when collided with marker
        if (start && Input.GetKey(KeyCode.Space))
        {
            slider.value += (sliderSpeed * Time.deltaTime);
        }

        
        if(slider.value == noteTime)
        {
            Debug.Log(timer);
        }

        //should be rewritten in future iteration (Short term solution)
        //pressing too early 
        if (!start && Input.GetKey(KeyCode.Space) && spacebarHeld == false || start && Input.GetKeyUp(KeyCode.Space) && timer < perfectEndTime)
        {
            StartCoroutine(feedback.EarlyFeedback());
        }
        else if (start && Input.GetKey(KeyCode.Space) && spacebarHeld && (timer <= perfectFrontTime) || start && Input.GetKeyUp(KeyCode.Space) && (timer < noteTime) && (timer > perfectEndTime))
        {
            if ((timer < noteTime) && (timer > perfectEndTime))
                start = false;
            StartCoroutine(feedback.PerfectFeedback());
        }
        //
        else if (start && spacebarHeld == true && timer > noteTime + .1|| start && spacebarHeld == false && timer > noteTime + padding || start && spacebarHeld == false && Input.GetKey(KeyCode.Space) && timer > perfectFrontTime && timer < noteTime)
        {
            StartCoroutine(feedback.LateFeedback());
        }

        if (timer > noteTime + 0.5)
            start = false;

        //Check if spacebar is held
        if (Input.GetKey(KeyCode.Space))
            spacebarHeld = true;
        else
            spacebarHeld = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Marker")
        {
            start = true;
            imageSlider.gameObject.SetActive(true);
        }
    }

    IEnumerator Flash()
    {
        Debug.Log("Flash");
        flashed = true;
        flash.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        flash.gameObject.SetActive(false);

    }
}
