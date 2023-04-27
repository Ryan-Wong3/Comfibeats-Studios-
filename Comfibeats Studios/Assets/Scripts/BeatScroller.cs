using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField]
    private float beatTempo = 120; //possibly insert music bpm here

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; //seconds into minute?
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasStarted)
        {
            transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);  //moves notes up smoothly (possible alter to do riggid effect
        }
    }
}
