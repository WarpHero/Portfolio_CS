using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeMove : MonoBehaviour
{
    public float MoveSpeed = 0.5f;

    public bool b;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0f, 0f, 1f);
        MoveSpeed = 1f;
        
        b = true; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (b)
        {
            transform.Translate(0f,(-1) * MoveSpeed * Time.deltaTime, 0f);
        }

        if (transform.position.y<0)
        {
            b=false;
        }
    }
}