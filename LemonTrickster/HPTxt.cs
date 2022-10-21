using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPTxt : MonoBehaviour
{

    TextMeshProUGUI hpTxt;
    int alp;

    // Start is called before the first frame update
    void Start()
    {
        hpTxt = GetComponent<TextMeshProUGUI>();
    }

    void TxtColor()
    {
        if (PlayerHealth.hp<=100)
        {
            hpTxt.color = new Color(0.3773585f, 0.3773585f, 0.3773585f, (PlayerHealth.hp / 100f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpTxt.text = "" + PlayerHealth.hp +"";
        TxtColor();
    }
}
