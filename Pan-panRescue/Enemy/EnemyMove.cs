using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemyPrefab;

    GameObject target;

    Vector3 dir;
    public float dist;

    float speed;
    float maxSpeed=3f;


    public float Speed
    {
        get { return speed; }

        protected set
        {
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            if (GameManager.instance.AddScore > 700)
            {
                speed = Random.Range(2, maxSpeed);
            }
            else if(GameManager.instance.AddScore > 500)
            {
                speed = Random.Range(1, 2);
            }

        }
    }


    private void Start()
    {
        dir=enemyPrefab.transform.position;
        target = GameObject.Find("Player");
        speed = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            dist=Vector3.Distance(enemyPrefab.transform.position, target.transform.position);
            //Vector3 dir= target.transform.position-transform.position;
            //dir.Normalize();
            //transform.Translate(dir * Time.deltaTime);
            if (dist > 2)
            {
                transform.Translate(enemyPrefab.transform.forward * Speed * Time.deltaTime);
            }
            else
            {
                Speed = 0;
                //transform.Translate(enemyPrefab.transform.forward * Speed * Time.deltaTime);
                transform.position = this.transform.position;
            }
        }

    }
    
}
