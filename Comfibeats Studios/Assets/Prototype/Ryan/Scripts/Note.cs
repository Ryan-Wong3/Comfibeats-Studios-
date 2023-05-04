using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Note : MonoBehaviour
{
    [SerializeField]
    private GameObject marker;

    [SerializeField]
    private float distance = 0;

    [SerializeField]
    private float breakingDistance = 0;

    [SerializeField]
    private bool start = false;
    private bool flashed = false;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image imageSlider;

    [SerializeField]
    private GameObject flash;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (marker.transform.position.y - transform.position.y);

        if(distance < breakingDistance && flashed == false)
        {
            //flash UI element
            StartCoroutine(Flash());
        }


        if (start && Input.GetKey(KeyCode.Space))
        {
            slider.value += .01f;
        }

    
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
