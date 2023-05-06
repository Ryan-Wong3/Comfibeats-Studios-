using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //possible change distancebetweennotes if bpm low and want more text on screen
    public float distanceBetweenNotes;

    public bool hasStarted;

    [SerializeField]
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasStarted)
        {
            //transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);  //moves notes up smoothly (possible alter to do riggid effect
            if(timer > GameManager.Instance.noteInterval)
            {
                transform.position += new Vector3(0f, distanceBetweenNotes, 0f);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
