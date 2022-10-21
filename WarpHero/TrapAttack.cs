using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public int damage=10;
    public bool bIn;

    float time;

    GameObject player;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject==player)
        {
            bIn = true;
            //player.GetComponent<PlayerHealth>().hp-=damage;
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;

        if (bIn&&time>2f)
        {
            player.GetComponent<PlayerHealth>().hp-=damage;
            bIn = false;
            time=0;
        }
    }
}
