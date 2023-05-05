using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField]
    private float noteTime;
    [SerializeField]
    private float perfectTime;
    [SerializeField]
    private float earlyTime;
    [SerializeField]
    private float lateTime;

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
        marker = GameObject.FindGameObjectWithTag("Marker");
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
        if(distance < breakingDistance && flashed == false)
        {
            //flash UI element
            StartCoroutine(Flash());
        }

        if (start)
        {
            timer += Time.deltaTime;
            seconds = timer % 60;
        }
      

        //Enable slider to move when collided with marker
        if (start && Input.GetKey(KeyCode.Space))
        {
            slider.value = sliderSpeed * Time.time;
        }

        if(slider.value == noteTime)
        {
            Debug.Log("done");
            Debug.Log(timer);
        }
        //pressing too early 
        if (!start && Input.GetKey(KeyCode.Space) && spacebarHeld == false)
        {
            StartCoroutine(feedback.EarlyFeedback());
        }
        else if(start && Input.GetKey(KeyCode.Space) && spacebarHeld == false && tracker)
        {
            StartCoroutine(feedback.PerfectFeedback());
        }
        else if (start && Input.GetKey(KeyCode.Space) && spacebarHeld == false && seconds < 4)
        {
            StartCoroutine(feedback.LateFeedback());
        }
        


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
