using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleInput : MonoBehaviour
{

    GameManager myManager;

    //stay in circle
    GameObject circle;
    RectTransform circRT;
    float circWidth;
    float circRad;
    Vector3 circPos;

    //sprite changes
    [SerializeField]
    Sprite emptySprite, filledSprite;
    SpriteRenderer myRend;

    //freezing ship info
    bool onShip = false;
    bool showGhost = false;
    Sprite currentShipImg;
    GameObject currentShipGhost;
    public GameObject currentShipPulser;
    Vector3 clickedPos;

    bool seeCursor = true;

    SoundManager soundManager;

    GameObject shipOn;

    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        circle = GameObject.Find("Circle");
    }

    // Start is called before the first frame update
    void Start()
    {
        circRT = circle.GetComponent<RectTransform>();
        circWidth = circRT.rect.width;
        //circWidth += 2f;
        circRad = circWidth / 2;
        circPos = circRT.position;

        myRend = gameObject.GetComponent<SpriteRenderer>();
        currentShipGhost = GameObject.Find("CurrentShipImg");
        currentShipGhost.SetActive(false);

        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        soundManager = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0f;
            if (Maths.PointInCircle(mousePos.x, mousePos.y, circPos.x, circPos.y, circRad))
            {
                transform.position = mousePos;
                if (seeCursor)
                {
                    soundManager.PlayRadar();
                    Cursor.visible = false;
                    // Cursor.SetCursor(null, Vector2.zero, cursorMode);
                    seeCursor = false;
                }
            }
            else
            {
                if (!seeCursor)
                {
                    StartCoroutine(soundManager.FadeSource());
                    Cursor.visible = true;
                    //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                    seeCursor = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && onShip && !showGhost)
            {
                //Debug.Log("save");
                soundManager.PlaySave();
                currentShipGhost.SetActive(true);
                currentShipGhost.GetComponent<SpriteRenderer>().sprite = currentShipImg;
                currentShipPulser.GetComponent<SpriteRenderer>().sprite = currentShipImg;
                currentShipGhost.GetComponent<Animator>().SetTrigger("pulseShip");
                clickedPos = mousePos;
                currentShipGhost.transform.position = shipOn.transform.position;
                showGhost = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ship" && !GameManager.gameOver) {
            myRend.sprite = filledSprite;
            Packet myMessage = collision.gameObject.GetComponent<Packet>();
            myManager.SetMessageInfoText(myMessage.radAngle, myMessage.declination, myMessage.message, myMessage.sprite);
            currentShipImg = collision.GetComponent<SpriteRenderer>().sprite;
            shipOn = collision.gameObject;
            onShip = true;
        }
    }

    public void TurnOffGhost() {
        currentShipGhost.SetActive(false);
        showGhost = false;
        myManager.ResetMessageInfoText();
        shipOn = null;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ship" && !GameManager.gameOver) {
            myRend.sprite = emptySprite;
            if (!showGhost) {
                myManager.ResetMessageInfoText();
            }
            //currentShipGhost.SetActive(false);
            currentShipImg = null;
            onShip = false;
        }
    }
}
