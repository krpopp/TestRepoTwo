using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInput : MonoBehaviour
{

    public string currentRA;
    public string currentDEC;
    public int currentSRC;

    public TMP_InputField raField;
    public TMP_InputField decField;

    // Start is called before the first frame update
    void Start()
    {
        raField.onValueChanged.AddListener(delegate { UpdateString(0); });
        decField.onValueChanged.AddListener(delegate { UpdateString(1); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateString(int fieldSwitch) {
        if (fieldSwitch == 0)
        {
            currentRA = raField.text;
        }
        else if (fieldSwitch == 1) {
            currentDEC = decField.text;
        }
    }
}
