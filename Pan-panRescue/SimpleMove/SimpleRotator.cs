using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    public GameObject[] obj;
    public float[] speed;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].transform.Rotate(new Vector3(0, speed[i] * Time.deltaTime, 0));
            }
        }
    }
}
