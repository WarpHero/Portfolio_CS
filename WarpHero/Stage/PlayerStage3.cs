using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStage3 : MonoBehaviour
{
    public GameObject nextStg;
    public GameObject nextBttn;


    public RawImage imgVic;

    int cntdown = 3;
    void StageOpen()
    {

    }

    void pVictory()
    {
        if (StageManager.score >= 150)
        {
            //NextStage로 넘어가기
            nextBttn.SetActive(true);
            nextStg.SetActive(true);

            //Time.timeScale = 0;

            GetComponent<Animator>().SetTrigger("Victory");
            //승리포즈
            imgVic.color = new Color(1, 1, 1, 1);
            //victory sign



            GetComponent<Animator>().SetTrigger("VictoryDance");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        nextBttn.SetActive(false);
        nextStg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        pVictory();
    }
}
