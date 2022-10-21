using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStage1 : MonoBehaviour
{

    public GameObject nextStg;
    public GameObject nextBttn;

    int cntdown = 3;
    void StageOpen()
    {

    }

    void pVictory()
    {
        if (StageManager.score >= 30)
        {
            //NextStage로 넘어가기
            nextBttn.SetActive(true);
            nextStg.SetActive(true);

            Time.timeScale = 0;

            //GetComponent<Animator>().SetTrigger("Victory");
            //승리포즈
            //imgVic.color = new Color(1, 1, 1, 1);
            //victory sign
            //
            //
            //GetComponent<Animator>().SetTrigger("VictoryDance");

        }
    }


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Stg1");
        
        nextBttn.SetActive(false);
        nextStg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        pVictory();
    }
}
