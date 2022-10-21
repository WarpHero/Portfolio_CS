using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    StageManager scoreamanager;

    public GameObject itemGlov1;
    public GameObject itemGlov2;

    PlayerAttack amt;

    void ScoreCount()
    {

        if (StageManager.sum >= 100 || StageManager.score >= 100)
        {
            //itemGlov1.SetActive(false);
            itemGlov2.SetActive(true);

           // amt.amount += 20;
        }

        else if (StageManager.sum >= 50||StageManager.score>=50)
        {
            itemGlov1.SetActive(true);

           // amt.amount += 30;

        }
         
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreCount();
        amt= GameObject.Find("Player").GetComponent<PlayerAttack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCount();
    }
}
