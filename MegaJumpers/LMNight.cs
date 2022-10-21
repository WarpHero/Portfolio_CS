using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LMNight : MonoBehaviour
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
        ibestScore = PlayerPrefs.GetInt("BestNightScore");
        ibestCoin = PlayerPrefs.GetInt("BestNightCoin");
        GameManager.instance.ResetPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelMaster.bEndGame)
        {
            iyourScore = GameManager.instance.AddScore(0);
            iyourCoin = GameManager.instance.AddCoin(0);

            if (iyourScore >= ibestScore)
            {
                ibestScore = iyourScore;
                PlayerPrefs.SetInt("BestNightScore", ibestScore);
            }

            if (iyourCoin >= ibestCoin)
            {
                ibestCoin = iyourCoin;
                PlayerPrefs.SetInt("BestNightCoin", ibestCoin);

                //if (ibestCoin >= 100) GameManager.instance.bHardClear = true;
            }
            yourScore.text = "your score is : " + iyourScore;
            bestScore.text = "best score is : " + ibestScore;


        }
    }
}
