using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LMNormal : MonoBehaviour
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
        ibestScore = PlayerPrefs.GetInt("BestNormalScore");
        ibestCoin = PlayerPrefs.GetInt("BestNormalCoin");
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
                PlayerPrefs.SetInt("BestNormalScore", ibestScore);
            }

            if (iyourCoin >= ibestCoin)
            {
                ibestCoin = iyourCoin;
                PlayerPrefs.SetInt("BestNormalCoin", ibestCoin);

                if (ibestCoin >= 100) GameManager.instance.bNormalClear = true;
            }
            yourScore.text = "your score is : " + iyourScore;
            bestScore.text = "best score is : " + ibestScore;

        }
    }
}