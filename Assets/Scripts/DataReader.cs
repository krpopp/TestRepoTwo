using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReader : MonoBehaviour
{

    public TextAsset dataFile;
    public TextAsset poetFile;

//    private char lineSep = ',';
    private char fieldSep = '#';

    public static List<string> allPossibleMessages = new List<string>();
    public static List<string> allPoetMessages = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        string[] messageData = dataFile.text.Split(fieldSep);
        foreach (string message in messageData) {
            allPossibleMessages.Add(message);
        }
        string[] poetData = poetFile.text.Split(fieldSep);
        foreach(string message in poetData)
        {
            allPoetMessages.Add(message);
        }
        //Debug.Log(allPossibleMessages[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
