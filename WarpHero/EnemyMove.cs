using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    public Transform[] EnemyPos;
    public float resTime;
    int i;

    
    void Serching()
    {
        nav.SetDestination(EnemyPos[i].position);
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        // 패트롤 사용 안 되는 문제
        //EnemyPos[0].position=new Vector3(8,0,0);
        //EnemyPos[1].position = new Vector3(-3, 0, -7);
        //EnemyPos[2].position = new Vector3(-9, 0, -7);
        //EnemyPos[3].position = new Vector3(-5, 0, -16);
        //EnemyPos[4].position = new Vector3(1, 0, 13);
        //EnemyPos[5].position = new Vector3(-12, 0, 9);
        //EnemyPos[6].position = new Vector3(-17, 0, -13);
        
        //
    }

    void Update()
    {
        resTime+=Time.deltaTime;

        if (resTime > 5f)
        {
            i=Random.Range(0,EnemyPos.Length);
            resTime=0;
        }

        float dist=Vector3.Distance(transform.position, player.position);

        if (nav.isOnNavMesh)
        {
            if (dist < 3)
            {

                nav.SetDestination(player.position);

            }
            else
            {
                Serching();
            }
        }

        if (StageManager.score >= 150)
        {
            GetComponent<NavMeshAgent>().enabled = false;

            //score 150이상일 때 게임 종료하므로 기능 종료
        }
       
    }
}
