using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonTree : MonoBehaviour
{
    public GameObject[] tree = new GameObject[8];

    bool b;
    
    // Start is called before the first frame update
    void Start()
    {
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (b&&Score.score==100)
        {
            Handheld.Vibrate();
            b = false;
        }

        if (Score.score >= 350)
        {
            Debug.Log(7);
            
            tree[6].SetActive(false);
            tree[7].SetActive(true);
        }
        else if (Score.score >= 300)
        {
            Debug.Log(6);
            
            tree[5].SetActive(false);
            tree[6].SetActive(true);
        }
        else if(Score.score >= 250)
        {
            Debug.Log(5);
            tree[4].SetActive(false);
            tree[5].SetActive(true);
        }
        else if(Score.score >= 200)
        {
            Debug.Log(4);
            
            tree[3].SetActive(false);
            tree[4].SetActive(true);
        }
        else if(Score.score >= 150)
        {
            Debug.Log(3);
            tree[2].SetActive(false);
            tree[3].SetActive(true);
        }
        else if(Score.score == 100)
        {
            Debug.Log(2);
            
            tree[1].SetActive(false);
            tree[2].SetActive(true);
        }
        else if (Score.score == 50)
        {
            
            Debug.Log(1);
            tree[0].SetActive(false);
            tree[1].SetActive(true);
        }

    }
}
