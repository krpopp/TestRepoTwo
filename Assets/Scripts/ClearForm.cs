using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearForm : MonoBehaviour
{

    Button myButt;

    [SerializeField]
    Button[] allButtons;

    [SerializeField]
    GameObject errorWindow;

    // Start is called before the first frame update
    void Start()
    {
        myButt = gameObject.GetComponent<Button>();
        myButt.onClick.AddListener(Confirm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Confirm()
    {
        errorWindow.SetActive(false);
        for(int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
        }
    }
}
