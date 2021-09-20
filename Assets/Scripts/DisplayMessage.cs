using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{

    [SerializeField]
    TMP_Text ra, dec, message;
    [SerializeField]
    Image srcImg;
    [SerializeField]
    ScrollRect scrollRect;
    [SerializeField]
    RectTransform messageObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(string raT, string decT, string messageT, int img)
    {
        scrollRect.content = messageObj;
        GameManager myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        ra.SetText(raT);
        dec.SetText(decT);
        message.SetText(messageT);
        srcImg.sprite = myManager.allShipSprites[img];
        //Canvas.ForceUpdateCanvases();
        Debug.Log(message.textInfo.lineCount);
    }
}
