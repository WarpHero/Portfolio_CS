using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public static int score;

    bool b;

    PlayerHealth playerH;

    public static int sum;

    public GameObject GMOver;
    public GameObject GMBtn;
    public TextMeshProUGUI gameover;



    public GameObject[]  hearts =  new GameObject[3];

    void SumSum()
    {
        sum += score;
    }

   void GameOver()
    {
        if (gameover != null && GMBtn != null && GMOver != null)
        {
            gameover.enabled = true;
            GMOver.SetActive(true);
            GMBtn.SetActive(true);
        }
        
        foreach (var h in hearts)
        {
            h.SetActive(true);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        var obj = FindObjectsOfType<StageManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //출처: https://wergia.tistory.com/191 [베르의 프로그래밍 노트:티스토리]


        sum += score;

        playerH = GameObject.Find("Player").GetComponent<PlayerHealth>();

        score = 0;
        
        gameover.enabled=false;
        GMOver.SetActive(false);
        GMBtn.SetActive(false);
        
        


    }

    // Update is called once per frame
    void Update()
    {
        //ScoreCount();

        
        if (playerH.playerheart == 2)
        {
            //Debug.Log("aa");
            hearts[2].SetActive(false);
            //Destroy(hearts[2]);
            //hearts[2] = null;
        }
        if(playerH.playerheart == 1)
        {
            hearts[1].SetActive(false );
            //Destroy(hearts[1]);
        }
        if (playerH.playerheart == 0)
        {
            hearts[0].SetActive(false);
            //Destroy(hearts[0]);

            GameOver();
        }


    }
}
