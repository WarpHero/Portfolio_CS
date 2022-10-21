using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    public GameObject Congrat;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 400)
        {
            Time.timeScale = 0;

            Congrat.SetActive(true);
        }
    }
}
