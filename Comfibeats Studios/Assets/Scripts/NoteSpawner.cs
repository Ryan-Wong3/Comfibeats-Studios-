using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner Instance; // Singleton

    [SerializeField]
    public float timer = 0;
    public float xPos;

    public GameObject[] notes;

    //for reading off text file
    List<string> fileLines;
    public int listIndex = 0;
    public GameObject recallTextObject;
    private TextMeshProUGUI textMeshProComponent;

    void Start()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
                // old code to test spawning in 4 different prefab
                int randomIndex = Random.Range(0, notes.Length);
                GameObject notePrefab = notes[randomIndex]; //make new object with random prefab 
                Instantiate(notePrefab);

                switch (randomIndex)
                {
                    case 0:
                        textMeshProComponent = notePrefab.transform.Find("Note/Fill Area/Note Text").GetComponentInChildren<TextMeshProUGUI>();
                        textMeshProComponent.SetText(fileLines[listIndex]);
                        break;
                    case 1:
                        textMeshProComponent = notePrefab.transform.Find("2 Note/Note 0.789 Variant (1)/Fill Area/Note Text").GetComponentInChildren<TextMeshProUGUI>();
                        textMeshProComponent.SetText(fileLines[listIndex]);
                        textMeshProComponent = notePrefab.transform.Find("2 Note/Note 0.789 Variant/Fill Area/Note Text").GetComponentInChildren<TextMeshProUGUI>();
                        textMeshProComponent.SetText("aaa");
                        break;
                }

                /*
                //create duplicate gameobject and sets text to what is in list
                GameObject textObject = Instantiate(recallTextObject);
                //TextMeshPro textMeshProComponent = textObject.GetComponent<TextMeshPro>();
                TextMeshProUGUI textMeshProComponent = textObject.transform.Find("Note/Fill Area/Note Text").GetComponentInChildren<TextMeshProUGUI>();
                textMeshProComponent.SetText(fileLines[listIndex]);
                */
                
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
