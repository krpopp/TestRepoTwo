using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitData : MonoBehaviour
{

    Button myButt;

    [SerializeField]
    GameObject submitWindow, errorWindow;

    [SerializeField]
    Button[] allButtons;

    [SerializeField]
    public TMP_InputField raField, decField;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        myButt = gameObject.GetComponent<Button>();
        myButt.onClick.AddListener(SubmitPop);
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SubmitPop() {
        if (ValidateData()) {
            submitWindow.SetActive(true);
            if (GameManager.isPoet)
            {
                GameManager.poetCounter++;
            }
            else
            {
                DataReader.allPossibleMessages.RemoveAt(GameManager.currID);
            }
        }
        else
        {
            errorWindow.SetActive(true);
        }
        soundManager.PlayMouse();
        for (int i = 0; i < allButtons.Length - 1; i++) {
            allButtons[i].interactable = false;
        }
    }

    bool ValidateData()
    {
        string inputString = raField.text + decField.text;
        foreach(KeyValuePair<int, string> pair in GameManager.valiDataDict)
        {
            if(inputString == pair.Value)
            {
                GameManager.justSeenMessage = pair.Key;
                return true;
            }
        } 
        return false;
    }


}
