using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneChanger : MonoBehaviour
{

    public GameObject[] plane=new GameObject[2];

    bool b;

    void Yellow()
    {
        plane[0].SetActive(false);
    }

    void Blue()
    {
        plane[1].SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("GoodLemon"))|| (other.CompareTag("GoodSeed")))
        {
            plane[0].SetActive(true);

            Invoke("Yellow", 0.3f);
        }
        else if ((other.CompareTag("BadLemon")) || (other.CompareTag("BadSeed")))
        {
            plane[1].SetActive(true);

            Invoke("Blue", 0.3f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        plane[0].SetActive(false);
        plane[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
