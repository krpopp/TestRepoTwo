using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    public int myId;
    string wholeData;

    char fieldSep = ',';
    
    public string radAngle;
    public string declination;
    public int sprite;
    public string message;

    public string validata;

    Sprite myImage;
    SpriteRenderer myRend;
    bool isPoet = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        myRend = gameObject.GetComponent<SpriteRenderer>();
        if (GameManager.storyCounter % 2 == 0 || DataReader.allPossibleMessages.Count <= 0)
        {
            CreateMyData(DataReader.allPoetMessages[GameManager.poetCounter]);
            myRend.sprite = myManager.poetSprite;
            isPoet = true;
            GameManager.isPoet = true;
            //GameManager.poetCounter++;
        }
        else {
            myId = Random.Range(0, DataReader.allPossibleMessages.Count);
            CreateMyData(DataReader.allPossibleMessages[myId]);
            //DataReader.allPossibleMessages.RemoveAt(myId);
            GameManager.currID = myId;
            myRend.sprite = myManager.allShipSprites[sprite];
        }
        //dataReader = GameObject.Find("Data Reader").GetComponent<DataReader>();
 
    }

    void CreateMyData(string myNewData)
    {

        wholeData = myNewData;
        string[] messageData = wholeData.Split(fieldSep);
        radAngle = messageData[0];
        declination = messageData[1];
        sprite = int.Parse(messageData[2]);
        message = messageData[3];
        validata = messageData[0] + messageData[1];
        GameManager.usedData.Add(GameManager.usedData.Count, wholeData);
        GameManager.valiDataDict.Add(GameManager.valiDataDict.Count, validata);
    }

}
