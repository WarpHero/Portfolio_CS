using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{

    public static int cnt=3;
    public TextMeshProUGUI countTxt;


    public void Counting()
    {
        countTxt.text = "" + cnt + "";
        cnt--;

    }


    // Start is called before the first frame update
    void Start()
    {
        countTxt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Counting", 1f);

        

        if (cnt <= 0)
        {
            CancelInvoke("Counting");
        }
    }
}
