using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //public static int score = 0;
    TextMeshProUGUI scoreTxt;

    public Slider scoreSlider;


    // Start is called before the first frame update
    void Start()
    {
        scoreTxt=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score : " + StageManager.score +" /150";
        scoreSlider.value = StageManager.score;
    }
}
