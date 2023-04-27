using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //for if note is pressable to be scored (near hit area)
    public bool canBePressed;

    //for highlight effect? (maybe change to play animation)
    private SpriteRenderer spriteRender;
    public Sprite defaultImage;
    public Sprite highlightedImage;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.Instance.keyToPress))
        {
            if(canBePressed)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Hit")
        {
            canBePressed = true;
        }

        if (other.tag == "Activator")
        {
            spriteRender.sprite = highlightedImage;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hit")
        {
            canBePressed = false;
        }

        if(other.tag == "Activator")
        {
            
            spriteRender.sprite = defaultImage;
        }
    }
}
