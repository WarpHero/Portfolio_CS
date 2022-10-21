using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 8f;

    

    public bool b, isMove;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void PMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
      

        if (h!=0)//h != 0 || v != 0
        {
            //Vector3 dir = h * Vector3.right + v * Vector3.forward;
            Vector3 dir = h*Vector3.right; //좌우로만 움직이도록
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }

    

    void pPosition()
    {
        if (Score.score == 100&&!b)
        {
            transform.position = transform.position + new Vector3(0, 0, -2);
            speed += 1f;
            b = true;
        }

        if(Score.score == 200&&b)
        {
            transform.position= transform.position + new Vector3(0, 0, -3);
            speed += 2f;
            b=false;
        }

        if (Score.score == 300&&!b)
        {
            transform.position = transform.position + new Vector3(0, 0, -4);
            speed += 3f;
            b = true;
        }

    }
    
    public void Die()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //PMove();
        //TouchMove();
        pPosition();

    }
}
