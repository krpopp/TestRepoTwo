using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public Vector3 moveDir;
    float speed = 0.5f;

    SpriteRenderer myRend;

    GameObject circle;
    RectTransform circRT;
    float circWidth;
    float circRad;
    Vector3 circPos;

    int lastHit = 0;
    GameManager myManager;
    ReticuleInput retScript;
    Animator myAnim;

    bool moved = false;
    float moveTime;
    float moveTimeReset = 100f;

    private void Awake()
    {
        circle = GameObject.Find("Circle");
    }

    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        retScript = GameObject.Find("Recticle").GetComponent<ReticuleInput>();
        myAnim = gameObject.GetComponent<Animator>();
        myRend = gameObject.GetComponent<SpriteRenderer>();
        circRT = circle.GetComponent<RectTransform>();
        circWidth = circRT.rect.width;
        circWidth += 2f;
        circRad = circWidth / 2;
        circPos = circRT.position;
        GameManager.shipOnScreen = true;
        moveTime = moveTimeReset;
    }

    // Update is called once per frame
    void Update()
    {
        //SmoothMove();
        if (!Maths.PointInCircle(gameObject.transform.position.x, gameObject.transform.position.y, circPos.x, circPos.y, circRad))
        {
            GameManager.shipOnScreen = false;
            retScript.TurnOffGhost();
            myManager.StartShipTimer();
            Destroy(gameObject);
        }
        //if (moved)
        //{
        //    moveTime -= Time.deltaTime;
        //    if(moveTime <= 0)
        //    {
        //        moveTime = moveTimeReset;
        //        StepMove();
        //    }
        //}
    }

    void SmoothMove()
    {
        Vector3 newPos = transform.position;
        newPos = newPos + (moveDir * speed);
        transform.position = newPos;
    }

    void StepMove() {
        Vector3 newPos = transform.position;
        newPos = newPos + (moveDir * speed);
        transform.position = newPos;
        moved = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "line" && lastHit != collision.gameObject.GetComponent<Radar>().rotCounter) {
            myAnim.SetTrigger("beFade");
            lastHit = collision.gameObject.GetComponent<Radar>().rotCounter;
            moved = true;
            StepMove();
        }
    }


}
