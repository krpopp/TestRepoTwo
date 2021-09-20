using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public GameObject line;
    Rigidbody2D lineBody;

    public int rotCounter;

    // Start is called before the first frame update
    void Start()
    {
        //line = gameObject.transform.Find("line").gameObject;
        lineBody = line.GetComponent<Rigidbody2D>();
        lineBody.rotation = 45f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateLine();
    }

    void RotateLine()
    {
        //lineBody.rotation += Time.deltaTime * 5f;
        //line.transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "lineCounter") {
            rotCounter++;
        }
    }

}
