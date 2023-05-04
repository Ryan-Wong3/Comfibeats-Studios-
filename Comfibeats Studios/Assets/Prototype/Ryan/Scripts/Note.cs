using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    [Header("Marker")]
    [SerializeField]
    private GameObject marker;

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

    // Start is called before the first frame update
    void Start()
    {
        
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
            slider.value += .01f;
        }

        //pressing too early 
        if (!start && Input.GetKey(KeyCode.Space) && spacebarHeld == false)
        {
            StartCoroutine(feedback.EarlyFeedback());
        }
        else if(start && Input.GetKey(KeyCode.Space) && spacebarHeld == false && seconds < 2)
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

        Debug.Log(spacebarHeld);
       

        

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
