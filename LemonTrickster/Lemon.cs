using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : MonoBehaviour
{
    public float speed = 16f;
    Rigidbody rb;

    //Camera cm;


    void ReturnCol()
    {
        //cm.backgroundColor = new Color(1, 1, 1, 1);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        //cm = GameObject.Find("Main Camera").GetComponent<Camera>();

        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove player = other.GetComponent<PlayerMove>();

            if (player != null)
            {
                //cm.backgroundColor = new Color(0.9f, 0.9f, 0.3f, 1f);

                //Invoke("ReturnCol", 0.2f);

                Score.score += 30;

                transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

                Destroy(gameObject, 1f);
            }
            
        }

    }
}
