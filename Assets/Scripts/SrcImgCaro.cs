using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SrcImgCaro : MonoBehaviour
{

    [SerializeField]
    Image srcImgDisplay;

    [SerializeField]
    GameManager myManager;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateImgLeft() {
        soundManager.PlayMouse();
        if(GameManager.srcImgCar > 0)
        {
            GameManager.srcImgCar--;
        }
        srcImgDisplay.sprite = myManager.allShipSprites[GameManager.srcImgCar];
    }

    public void RotateImgRight()
    {
        soundManager.PlayMouse();
        if (GameManager.srcImgCar < myManager.allShipSprites.Length-1)
        {
            GameManager.srcImgCar++;
        }
        srcImgDisplay.sprite = myManager.allShipSprites[GameManager.srcImgCar];
    }
}
