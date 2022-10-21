using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static int hp;
    public int max = 100;
    public Slider hpSlider;


    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
    }

    // Update is called once per frames
    void Update()
    {
        hpSlider.value = hp;
    }
}
