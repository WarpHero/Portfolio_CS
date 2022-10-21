using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }


        if (transform.position.z < -35f)
        {
            Destroy(gameObject);
        }
    }
}
