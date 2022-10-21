using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchMove : MonoBehaviour
{
    Rigidbody rb;
    float speed = 500f;

    //TouchMove
    public TextMeshProUGUI test;
    Vector2 startTouchPos, currentTouchPos, endTouchPos;
    bool stopTouch;
 

    public float swipeRange;
    public float tapRange;


    void TouchMovef()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPos = Input.GetTouch(0).position;
            Vector2 Dist = currentTouchPos - startTouchPos;

            if (!stopTouch)
            {

                if (Dist.x < -swipeRange)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(Vector2.left * speed);
                    test.text = "left";
                    stopTouch = true;
                }
                else if (Dist.x > swipeRange)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(Vector2.right * speed);
                    test.text = "right";
                    stopTouch = true;
                }
                else if (Dist.y > swipeRange)
                {
                    //rb.AddForce(Vector2.up * speed);
                    test.text = "up";
                    stopTouch = true;
                }
                else if (Dist.y < -swipeRange)
                {
                    //rb.AddForce(Vector2.up * speed);
                    test.text = "down";
                    stopTouch = true;
                }

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPos = Input.GetTouch(0).position;

            Vector2 dist = endTouchPos - startTouchPos;

            if (Mathf.Abs(dist.x) < tapRange && Mathf.Abs(dist.y) < tapRange)
            {
                rb.velocity = new Vector3(0, 0, 0);
                test.text = "tap";
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        swipeRange = 50;
        tapRange = 10;
    }

    // Update is called once per frame
    void Update()
    {
        TouchMovef();
    }
}
