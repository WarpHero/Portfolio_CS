using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LMEasy : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI bestScore;
    int iyourScore;
    int iyourCoin;
    int ibestScore;
    int ibestCoin;

    // Start is called before the first frame update
    void Start()
    {
        //lm=FindObjectOfType<LevelMaster>();
        ibestScore = PlayerPrefs.GetInt("BestEasyScore");
        ibestCoin = PlayerPrefs.GetInt("BestEasyCoin");
        GameManager.instance.ResetPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelMaster.bEndGame)
        {
            iyourScore = GameManager.instance.AddScore(0);
            iyourCoin=GameManager.instance.AddCoin(0);

            if (iyourScore >= ibestScore)
            {
                ibestScore=iyourScore;
                PlayerPrefs.SetInt("BestEasyScore", ibestScore);
            }

            if(iyourCoin >= ibestCoin)
            {
                ibestCoin=iyourCoin;
                PlayerPrefs.SetInt("BestEasyCoin", ibestCoin);

                if (ibestCoin >= 100) GameManager.instance.bEasyClear = true;
            }
            yourScore.text = "your score is : " + iyourScore;
            bestScore.text = "best score is : " + ibestScore;

            
        }
    }
}
