using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MIFKeys : MonoBehaviour
{

    public TMP_InputField raField;
    public TMP_InputField decField;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (raField.isFocused)
            {
                decField.Select();
            }
            else if (decField.isFocused)
            {
                raField.Select();
            }
        }
   
    }
}
