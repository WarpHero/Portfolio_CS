using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHeal : MonoBehaviour
{
    public int heal = 20;
    public float time;
    public bool bIN;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bIN = false;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            bIN= true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        time+=Time.deltaTime;

        if (other.gameObject == player && time>1f && bIN)
        {
            player.GetComponent<PlayerHealth>().hp+=heal;
            
            //player.GetComponent<PlayerHealth>().imgBar.transform.localScale =
            //   new Vector3(hp / 200.0f, 1, 1);

            bIN= false;
            //time=0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject==player)
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
