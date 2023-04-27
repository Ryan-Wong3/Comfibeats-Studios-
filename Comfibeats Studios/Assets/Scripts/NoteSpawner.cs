using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public float maxTime = 1;   //time before next spawn (probably for next lit up line)
    [SerializeField]
    private float timer = 0;
    public GameObject note;
    public float x;

    //for varying text length?
    public List<string> sentenceLengths { get; private set; } // Readonly list storing affected tiles    
    // Start is called before the first frame update
    void Start()
    {
        /*  //testing purposes
        GameObject newNote = Instantiate(note);
        newNote.transform.position = transform.position + new Vector3(Random.Range(-x, x), 0, 0);
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasStarted)
        {
            if (timer > maxTime)
            {
                GameObject newNote = Instantiate(note);
                newNote.transform.position = transform.position + new Vector3(Random.Range(-x, x), 0, 0);
                //newNote.transform.position = transform.position + new Vector3(-x, 0, 0);    //left justified for words
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
