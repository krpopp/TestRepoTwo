using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMessage : MonoBehaviour
{

    Button myButton;

    [SerializeField]
    Button[] allButtons;


    [SerializeField]
    GameObject submitWindow;

    GameManager myManager;

    SoundManager soundManager;

    [SerializeField]
    GameObject savingWindow;

    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
        myButton = gameObject.GetComponent<Button>();
        if (gameObject.name == "Save Button")
        {
            myButton.onClick.AddListener(AddMessageToList);
        }
        else if (gameObject.name == "Delete Button") {
            myButton.onClick.AddListener(ResetScreen);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddMessageToList() {
        soundManager.PlayMouse();
        soundManager.PlayLight();
        SavingMessageWindow();
        myManager.CreateMessage(GameManager.srcImgCar);
        ResetScreen();
    }

    void ResetScreen()
    {
        soundManager.PlayMouse();
        submitWindow.SetActive(false);
        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
        }
    }

    void SavingMessageWindow()
    {
        soundManager.SaveMessage();
        savingWindow.SetActive(true);
    }


}
