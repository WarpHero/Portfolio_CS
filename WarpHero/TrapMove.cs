using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    //trap은 static 끄기

    float Speed = 0.5f;
    int i;
    public bool bMove;
    Vector3 pos;

    float timer;
    
    void Trapping()
    {
        //trap 상하 운동
        if (pos.y >= 0)
        {
            bMove = true;
        }
        else if (pos.y <= -1)
        {
            bMove = false;
        }


        if (bMove)
        {
            pos.y -= Speed * Time.deltaTime;

            transform.position = pos;
        }
        else
        {
            pos.y += Speed * Time.deltaTime;

            transform.position = pos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pos=transform.position;
        bMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        Trapping();

        //transform.Rotate(0f, (-1)*Speed*Time.deltaTime, 0f);

    }
}
