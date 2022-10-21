using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStage2 : MonoBehaviour
{

    public GameObject nextStg;
    public GameObject nextBttn;

    public GameObject ready;
    int cntdown = 3;

    float time=0;
    //bool a = false;
    void StageOpen()
    {
        //for(int i = 0; i < 3; i++)
        //{
        //    ready.text = "" + cntdown + "";
        //    cntdown--;
        //}
        //Debug.Log("aa");
        ready.SetActive(false);

        Time.timeScale = 1;
    }

    void pVictory()
    {
        if (StageManager.score >= 100)
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
        Debug.Log("Stg2");

        Time.timeScale = 1;

        nextBttn.SetActive(false);
        nextStg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //if (a == false)
        //{
        //    Invoke("StageOpen", 3);
        //    a = true;
        //}
        pVictory();
    }
}
