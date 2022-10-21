using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonManager<LevelManager>
{

    EnemyMove[] em;
    EnemyState[] es;
    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.instance.isGameover = false;
        GameManager.instance.ScoreReset();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            EnemyManager.instance.enabled = false;

            em=FindObjectsOfType<EnemyMove>();
            es = FindObjectsOfType<EnemyState>();

            for(int i=0;i<em.Length; i++)
            {
                em[i].enabled=false;
                es[i].enabled = false;
            }
        }
    }
}
