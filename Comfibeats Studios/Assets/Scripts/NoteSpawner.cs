using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private float timer = 0;
    public float xPos;

    public GameObject[] notes;

    //for reading off text file
    List<string> fileLines;
    public int listIndex = 0;
    public GameObject recallTextObject;
    void Start()
    {
        /*  //testing purposes
        GameObject newNote = Instantiate(note);
        newNote.transform.position = transform.position + new Vector3(Random.Range(-x, x), 0, 0);
        */

        //reads text file from file path and puts each line into a list
        string readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "Chat" + ".txt";
        fileLines = File.ReadAllLines(readFromFilePath).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasStarted)
        {
            if (timer > GameManager.Instance.noteInterval)
            {
                /* old code to test spawning in 4 different prefab
                //int randomIndex = Random.Range(0, notes.Length);
                //GameObject notePrefab = notes[randomIndex]; //make new object with random prefab 
                //Instantiate(notePrefab);
                */
                
                //create duplicate gameobject and sets text to what is in list
                GameObject textObject = Instantiate(recallTextObject);
                //TextMeshPro textMeshProComponent = textObject.GetComponent<TextMeshPro>();
                TextMeshProUGUI textMeshProComponent = textObject.transform.Find("Slider/Fill Area/Text").GetComponentInChildren<TextMeshProUGUI>();
                textMeshProComponent.SetText(fileLines[listIndex]);
                
                //spawns text at notespawner + offset
                //textObject.transform.position = transform.position + new Vector3(xPos, 0, 0);

                //repeat last line if at end of txt 
                if (fileLines.Count - 1 > listIndex)
                {
                    listIndex++;
                }
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
