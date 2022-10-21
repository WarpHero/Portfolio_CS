using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 100;
    public RawImage imgBar;

    public AudioClip clipDeath;

    Animator anim;

    public void Damage(int amount)
    {
        if (hp <= 0) return;

        hp-=amount;
        imgBar.transform.localScale=new Vector3(hp/100.0f, 1, 1);

        if (hp <= 0)
        {
            anim.SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;

            GetComponent<AudioSource>().PlayOneShot(clipDeath);


            Destroy(gameObject, 1);
            
            StageManager.score += 30;

            //GameObject.Find("GameManager").GetComponent<Spawn>().count--;
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
