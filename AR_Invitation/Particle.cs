using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    public GameObject[] party;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //party[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        timer+=Time.deltaTime; 


        if(party[0] != null&&timer>8f)
        {
           
            party[1].SetActive(true);

            Invoke("party2", 1f);
            
        }
    }

    void party2()
    {
        party[2].SetActive(true);
    }

   
}
