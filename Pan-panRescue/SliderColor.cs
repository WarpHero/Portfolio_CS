using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    float Col;
    //Slider slider;
    public SliderColor slidercolor;
    public Color colorred = new Color(1,0,0,0.5f);
    public Color startColor;
    public Color color;
    float remainHP;
    Player player;

    private void Start()
    {
        //slider=GetComponent<Slider>();
        slidercolor = GetComponent<SliderColor>();
        player = FindObjectOfType<Player>();
        slidercolor.color = new Color(0.1019608f, 0.6666667f, 0.8039216f, 0.5882353f);
        startColor=slidercolor.color;
    }
    // Update is called once per frame
    void Update()
    {
        remainHP = (player.HP / player.maxHP);
        if (remainHP < 0.4f)
        {
            slidercolor.color = Color.Lerp(colorred, startColor, remainHP);
        }
    }
}
