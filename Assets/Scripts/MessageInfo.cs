using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageInfo : MonoBehaviour
{

    public int myId;

    public TMP_Text messagePrev;

    Button myButton;

    GameObject myPanel;

    GameObject inboxContent;
    GameObject messageContent;

    public Image myImage;
    public int myNewImage;

    GameManager myManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
        string allData = GameManager.usedData[myId];
        string[] splitData = allData.Split(',');
        messagePrev.SetText(splitData[3]);
        myButton.onClick.AddListener(OpenMessage);

        myPanel = GameObject.Find("Panel 2");
        inboxContent = myPanel.transform.GetChild(0).transform.GetChild(1).gameObject;
        messageContent = myPanel.transform.GetChild(0).transform.GetChild(0).gameObject;
        myImage.sprite = myManager.allShipSprites[myNewImage];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OpenMessage()
    {
        soundManager.PlayMouse();
        inboxContent.SetActive(false);
        messageContent.SetActive(true);
        string allData = GameManager.usedData[myId];
        string[] splitData = allData.Split(',');
        DisplayMessage myMessageScript = messageContent.GetComponent<DisplayMessage>();
        myMessageScript.SetInfo(splitData[0], splitData[1], splitData[3], myNewImage);
        GameManager.currentMessage = myId;
    }
}
