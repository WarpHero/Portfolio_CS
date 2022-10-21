using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public bool bIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //bIn = true;
            Destroy(gameObject);
        }
    }

    //void twinkl()
    //{
    //   if (bIn)
    //    {
    //        GetComponent<StarMove>().enabled = false;
    //    }

    //    Invoke("antitwinkl", 5);
    //}

    //void antitwinkl()
    //{
    //    GetComponent <StarMove>().enabled = true;
    //    bIn = false;
    //}
    // Start is called before the first frame update
    void Start()
    {
        //bIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
