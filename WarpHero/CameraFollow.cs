using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform p;
    // Start is called before the first frame update
    void Start()
    {
        p=GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = p.position + new Vector3(0.5f, 8, -15);
        //0.5f, 8, 15 ���µ� ĳ���� ������ ������ ��Ī���� ��

        
    }
}
