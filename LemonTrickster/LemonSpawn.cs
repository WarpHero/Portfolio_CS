using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonSpawn : MonoBehaviour
{

    public GameObject[] badPrefab;
    public GameObject[] goodPrefab;

    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    Transform target;
    public Transform[] Pos;

    float BspawnRate;
    float GspawnRate;
    float timeAfterBSpawn;
    float timeAfterGSpawn;
    
    public int i, j, k;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterBSpawn = 0f;
        BspawnRate=Random.Range(spawnRateMin,spawnRateMax);
        GspawnRate=Random.Range(spawnRateMin,spawnRateMax);

        target=FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterBSpawn += Time.deltaTime;
        timeAfterGSpawn += Time.deltaTime;

        //Vector3 dir = target.position - transform.position;

        if (timeAfterBSpawn >= BspawnRate)
        {
            timeAfterBSpawn=0;
            i=Random.Range(0, badPrefab.Length);

            GameObject badlemon =
                Instantiate(badPrefab[i], transform.position + new Vector3(0f, 0.5f, 0f) , transform.rotation);

            badlemon.transform.LookAt(target);

            BspawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

        if (timeAfterGSpawn >= GspawnRate)
        {
            timeAfterGSpawn = 0;
            j=Random.Range(0, goodPrefab.Length);
            k=Random.Range(0, Pos.Length);

            GameObject goodlemon =
                Instantiate(goodPrefab[j], transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);

            goodlemon.transform.LookAt(Pos[k]);
            GspawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        
    }
}
