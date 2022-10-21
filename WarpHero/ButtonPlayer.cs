using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayer : MonoBehaviour
{


    public GameObject btnStart;

    public float speed=5;

    public void ButtonEvent()
    {
        transform.Translate(0f, 10f, 0f);
    }

    //public void ButtonEvent32()
    //{
    //    transform.localScale = Vector3.one;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
