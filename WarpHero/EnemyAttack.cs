using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    GameObject player;
    Animator anim;
    float time;
    bool bInRange;

    public AudioClip clipAttack;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
       anim=GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bInRange=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;

        if (time >= 0.5f && bInRange)
        {
            time = 0;
            player.GetComponent<PlayerHealth>().Damage(50);
            anim.SetBool("bAttack", true);

            GetComponent<AudioSource>().PlayOneShot(clipAttack);
            
            if (player.GetComponent<PlayerHealth>().hp <= 0)
            {
                anim.SetTrigger("PlayerDeath");
            }
            anim.SetBool("bAttack", false);   
        }
    }
}
