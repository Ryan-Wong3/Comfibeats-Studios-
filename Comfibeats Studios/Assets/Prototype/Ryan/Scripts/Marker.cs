using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    [SerializeField]
    private bool start = false;

    [SerializeField]
    private GameObject highlight;
    [SerializeField]
    private Slider sliderLight;

    [SerializeField]
    private float radius;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (highlight != null && Input.GetKeyDown(KeyCode.Space)){
            if (sliderLight != null)
            {
                sliderLight.value += .01f;
            }
        }
        if(highlight != null && Input.GetKey(KeyCode.Space))
        {
            sliderLight.value += .01f;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Testing");
        if (other.tag == "Note")
        {
            highlight = other.gameObject;
            if (highlight.GetComponent<Slider>())
            {
                sliderLight = highlight.GetComponent<Slider>();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
