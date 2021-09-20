using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackInbox : MonoBehaviour
{

    [SerializeField]
    Button myButton;

    [SerializeField]
    GameObject inboxContent, messageContent;

    SoundManager soundManager;

    [SerializeField]
    ScrollRect scrollRect;
    [SerializeField]
    RectTransform inboxObj;

    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(GoBack);
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack()
    {
        scrollRect.content = inboxObj;
        soundManager.PlayMouse();
        inboxContent.SetActive(true);
        messageContent.SetActive(false);
    }
}
