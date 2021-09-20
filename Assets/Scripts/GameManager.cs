using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //public 
    public GameObject currentTab;

    //Save messages
    [SerializeField]
    GameObject messagesContainer, msgPrefab;
    [SerializeField]
    int ttlMessages;
    List<GameObject> savedMessages = new List<GameObject>();

    //RADAR and ship creation
    [SerializeField]
    GameObject radarObj, shipPrefab;
    [SerializeField]
    float radarRange;
    Vector3 radarPos;

    //RADAR info display
    [SerializeField]
    GameObject raObj, decObj, srcImg, messageTab, noMessageTab; //mesObj;
    TMP_Text raMesh, decMesh; //mesMesh;
    Image srcImgDis;

    public static Dictionary<int, string> usedData = new Dictionary<int, string>();
    public static Dictionary<int, string> valiDataDict = new Dictionary<int, string>();
    public static int justSeenMessage;

    public static int currentMessage;

    public Sprite[] allShipSprites;

    public static int srcImgCar = 0;
    [SerializeField]
    Image caroSrcImg;

    [SerializeField]
    SpriteRenderer[] allLightSprites;
    [SerializeField]
    Sprite litSprite;
    [SerializeField]
    Animator[] allLightAnimators;

    int storage = -1;

    public Texture2D cursorTexture;
    public Texture2D digiTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    bool showCursor = true;

    public GameObject innerCursor;

    public GameObject currentShip;

    public static bool shipOnScreen = false;

    public static int storyCounter = 0;
    public static int poetCounter = 0;

    public Sprite poetSprite;

    public static bool gameOver = false;
    public GameObject gameOverObj;

    public static bool isPoet = false;
    public static int currID = -1;

    public Animator lineAnim;
    public Animator reticleAnim;
    public Animator cursorAnim;

    public GameObject endScreen;
    public GameObject endCanvas;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //CreateInitMessages();
        radarPos = radarObj.transform.localPosition;
        raMesh = raObj.GetComponent<TMP_Text>();
        decMesh = decObj.GetComponent<TMP_Text>();
        srcImgDis = srcImg.GetComponent<Image>();
        //screenRect = mainScreen.rect;
        //mesMesh = mesObj.GetComponent<TextMeshPro>();
        if (!shipOnScreen)
        {
            CreateShip();
        }
        caroSrcImg.sprite = allShipSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0f;
            if (mousePos.x > -1f && mousePos.x < 6.7f && mousePos.y > -2f && mousePos.y < 3.8f)
            {
                if (showCursor)
                {
                    Cursor.visible = false;
                    showCursor = false;
                }
            }
            else
            {
                if (!showCursor)
                {
                    Cursor.visible = true;
                    showCursor = true;
                }
            }
            if (!showCursor)
            {
                innerCursor.transform.position = mousePos;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentTab.SetActive(false);
        //    gameOverObj.SetActive(true);
        //    GameOver();
        //    gameOver = true;
        //}

    }

    public void CreateMessage(int newImg) {
        if (storage < 6)
        {
            GameObject newMsg = Instantiate(msgPrefab, transform.position, Quaternion.identity);
            //newMsg.SetActive(false);
            newMsg.transform.SetParent(messagesContainer.transform);
            newMsg.transform.localScale = new Vector3(1f, 1f, 1f);
            newMsg.transform.localPosition = new Vector3(0f, 0f, 0f);
            newMsg.GetComponent<MessageInfo>().myId = justSeenMessage;
            newMsg.GetComponent<MessageInfo>().myNewImage = newImg;
            savedMessages.Add(newMsg);
            AddToStorage();
            //AdjustMessages();
        }
        else {
            currentTab.SetActive(false);
            gameOverObj.SetActive(true);
            GameOver();
            gameOver = true;
        }

    }

    void GameOver() {
        gameObject.GetComponent<SoundManager>().PlayEndSound();
        GameObject.Destroy(currentShip);
        for(int i = 0; i < allLightAnimators.Length; i++)
        {
            allLightAnimators[i].SetBool("gameOver", true);
        }
        lineAnim.SetBool("gameOver", true);
        cursorAnim.SetBool("gameOver", true);
        reticleAnim.SetBool("gameOver", true);
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(2f);
        endScreen.SetActive(true);
        endCanvas.SetActive(true);
    }

    void AdjustMessages() {
        for(int i = 0; i < savedMessages.Count; i++)
        {
            if(savedMessages.Count >= 5 && i >= 5)
            {
                RectTransform parentRect = messagesContainer.GetComponent<RectTransform>();
                parentRect.offsetMin = new Vector2(parentRect.offsetMin.x, parentRect.offsetMin.y - 125f);
            }
        }
        for(int i = 0; i < savedMessages.Count; i++)
        {
            float startY = -80f;
            Vector3 newPos = new Vector3(savedMessages[i].transform.position.x + 150f, startY - (i * 60f));
            savedMessages[i].transform.localPosition = newPos;
        }
    }

    void AddToStorage()
    {
        storage++;
        for(int i = 0; i <= storage; i++)
        {
            allLightAnimators[i].SetTrigger("turnOn");
            //allLightSprites[i].sprite = litSprite;
        }
    }

    //void CreateInitMessages() {
    //    for (int i = 0; i < ttlMessages; i++) {
    //        GameObject newMsg = Instantiate(msgPrefab, transform.position, Quaternion.identity);
    //        newMsg.transform.SetParent(messagesContainer.transform);
    //        newMsg.transform.localScale = new Vector3(1f, 1f, 1f);
    //        newMsg.transform.localPosition = new Vector3(0f, 0f, 0f);

    //        if (ttlMessages >= 5 && i >= 5) {
    //            RectTransform parentRect = messagesContainer.GetComponent<RectTransform>();
    //            parentRect.offsetMin = new Vector2(parentRect.offsetMin.x, parentRect.offsetMin.y - 65f);
    //        }

    //        savedMessages.Add(newMsg);
    //    }
    //    for (int i = 0; i < ttlMessages; i++) {
    //        float startY = -100f;
    //        Vector3 newPos = new Vector3(savedMessages[i].transform.position.x + 190f, startY - (i * 60f));
    //        savedMessages[i].transform.localPosition = newPos;
    //    }
    //}

    void CreateShip() {
        float randX = Random.Range(radarPos.x - radarRange, radarPos.x + radarRange);
        //Debug.Log(radarPos.x + radarRange);
        float randY = Random.Range(radarPos.y - radarRange, radarPos.y + radarRange);
        //Debug.Log(randX);
        Vector3 randPos = new Vector3(randX, randY);
        GameObject newShip = Instantiate(shipPrefab, randPos, Quaternion.identity);
        Vector3 randDir = Vector3.zero;
        if (randPos.x < radarPos.x)
        {
            randDir = new Vector3(Random.Range(0.1f, 1f), randDir.y);
        }
        else if (randPos.x >= radarPos.x) {
            randDir = new Vector3(Random.Range(-0.1f, -1f), randDir.y);
        }
        if (randPos.y < radarPos.y)
        {
            randDir = new Vector3(randDir.x, Random.Range(0.1f, 1f));
        }
        else if (randDir.y >= radarPos.y){
            randDir = new Vector3(randDir.x, Random.Range(-0.1f, -1f));
        }
        newShip.GetComponent<Ship>().moveDir = randDir;
        currentShip = newShip;
        storyCounter++;
    }

    public void SetMessageInfoText(string aR, string dec, string mes, int img) {
        messageTab.SetActive(true);
        noMessageTab.SetActive(false);
        //if (raMesh != null) {
            raMesh.SetText(aR);
            decMesh.SetText(dec);
        //}
        // mesMesh.SetText(mes);
        srcImgDis.sprite = allShipSprites[img];
    }

    public void ResetMessageInfoText()
    {
        noMessageTab.SetActive(true);
        messageTab.SetActive(false);
        //if (raMesh != null) {
            raMesh.SetText("");
            decMesh.SetText("");
        //}
      //  mesMesh.SetText("");
    }

    public void StartShipTimer()
    {
        StartCoroutine(TimeShipCreate());
    }

    IEnumerator TimeShipCreate()
    {
        yield return new WaitForSeconds(1f);
        CreateShip();
    }
}
