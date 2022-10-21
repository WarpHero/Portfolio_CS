using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverScore : MonoBehaviour
{
    public TextMeshProUGUI gameoverScore;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            gameoverScore.text="부족한 점수 : "+
                (GameManager.instance.MaxScore-GameManager.instance.AddScore);
        }
    }
}
