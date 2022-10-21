using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLemon : MonoBehaviour
{
    float speed = 25f;
    public bool b;

    public float timer;

    RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        b = true;
        rectTrans = GetComponent<RectTransform>();
        transform.position=new Vector3((float)rectTrans.position.x, (float)rectTrans.position.y, (float)rectTrans.position.z);
        //rectTrans.position = new Vector3(0, 259f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(b)
        {
            rectTrans.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
        }
        if(timer>=14)
        {
            b=false;
            //transform.position = new Vector3(-400f, 0f, 0f);
        }
        
    }
}
