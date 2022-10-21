using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    bool b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.score == 100&&!b)
        {
            transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            b = true;
        }

        if (Score.score == 200&&b)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            b = false;
        }
        if (Score.score == 300&&!b)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            b = true;
        }

    }
}
