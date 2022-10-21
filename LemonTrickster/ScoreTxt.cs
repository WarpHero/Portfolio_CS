using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTxt : MonoBehaviour
{
    

    TextMeshProUGUI txtScore;

    // Start is called before the first frame update
    void Start()
    {
        txtScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "SCORE : " + Score.score;
    }
}
