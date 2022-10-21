using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{

    public Transform pos;
    public Transform startPos;
    NavMeshAgent nav;

    public float timer;

    Animator anim;

    public float speed = 0.01f;


    // Start is called before the first frame update
    void Start()
    {

        transform.position = startPos.position;
        anim = GetComponent<Animator>();

        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(pos.position);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 8f)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            anim.SetTrigger("Clap");
            anim.SetTrigger("Dance");

        }

        //transform.Rotate(0f, speed, 0f);
    }
}
