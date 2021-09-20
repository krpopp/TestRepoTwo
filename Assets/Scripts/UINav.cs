using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UINav : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler{
    //inspector fields
    [SerializeField]
    GameObject myTab;

    //references
    GameManager myManager;
    Button myButton;

    [SerializeField]
    public Sprite idleButton, hoverButton, pressButton;

    [SerializeField]
    GameObject[] otherButtons;



    Image myImage;

    bool justPressed = false;

    public bool onTab;

    SoundManager soundManager;

    void Start()
    {
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        myImage = gameObject.GetComponent<Image>();
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClick);
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    void TaskOnClick() {
        if (myTab.name != myManager.currentTab.name && !GameManager.gameOver)
        {
            otherButtons[0].GetComponent<Image>().sprite = otherButtons[0].GetComponent<UINav>().idleButton;
            otherButtons[1].GetComponent<Image>().sprite = otherButtons[1].GetComponent<UINav>().idleButton;
            otherButtons[0].GetComponent<UINav>().onTab = false;
            otherButtons[1].GetComponent<UINav>().onTab = false;
            myTab.SetActive(true);
            myManager.currentTab.SetActive(false);
            onTab = true;
            myImage.sprite = pressButton;
            myManager.currentTab = myTab;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!onTab)
        {
            myImage.sprite = hoverButton;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!onTab)
        {
            myImage.sprite = idleButton;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (!onTab)
        {
            soundManager.PlayButtonRelease();
            myImage.sprite = idleButton;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!onTab)
        {
            soundManager.PlayButtonPress();
            myImage.sprite = pressButton;
        }
    }

}


