using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTrees : MonoBehaviour
{
    public GameObject[] tree = new GameObject[4];

    float time;

    // Start is called before the first frame update
    void Start()
    {
        tree[0].SetActive(false);
        tree[1].SetActive(false);
        tree[2].SetActive(false);
        tree[3].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 8f)
        { 
            tree[2].SetActive(false);
            tree[3].SetActive(true);
            time = 0;

        }
        else if (time >= 6f)
        {
            tree[1].SetActive(false);
            tree[2].SetActive(true);
        }
        else if (time >= 4f)
        {
            tree[0].SetActive(false);
            tree[1].SetActive(true);
        }
        else if (time >= 2f)
        {
            //tree[3].GetComponent<MeshRenderer>().material.color = new Color.
            tree[3].SetActive(false);
            tree[0].SetActive(true);
        }
    }
}
