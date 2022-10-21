using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextClick : MonoBehaviour
{
    TextMeshProUGUI text;

    bool b;
    public float timer;
    public int t;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;

        t=Mathf.RoundToInt(timer);

        if (t%2==0)
        {
            text.text = "<size=80><color=#ffda00>Click!</color>";
            //timer = 0f;
            b = false;
        }
        else
        {
            
            text.text = "<color=#ffffff>Click!</color>";
            b = true;
        }
        
    }
}
