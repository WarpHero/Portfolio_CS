using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : LivingEntity
{
    public GameObject damageactionPanel;
    public TextMeshProUGUI HPvalue;
    //public RawImage imgDamage; //8주차 원고

    public GameObject GameoverPanel;


    public override void OnEnable()
    {
        base.OnEnable();
        damageactionPanel.SetActive(false);
        GameoverPanel.SetActive(false);
        GameManager.instance.isGameover = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player HP - "+ HP);
        HPvalue.text = HP + "";
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    public override void AddDamage(int damage)
    {
        base.AddDamage(damage);
        HPvalue.text =HP+"";
        //Debug.Log(HP);
    }
    public override void ActionDamage()
    {
        //player가 damage를 받으면 damagepanel이 번쩍거린다.

        StartCoroutine(damageaction());

        IEnumerator damageaction()
        {
            Time.timeScale = 1.2f;
            for(int i = 0; i < 4; i++)
            {
                damageactionPanel.SetActive(true);
                yield return new WaitForSeconds(0.01f);
                damageactionPanel.SetActive(false);
                yield return new WaitForSeconds(0.01f);
                

                //imgDamage.color=Color.Lerp(imgDamage.color, Color.clear, 5 * Time.deltaTime);
                //Lerp쓰는 방법
            }
        }
    }
    public override void Die()
    {
        base.Die();
        GameoverPanel.SetActive(true);
        GameManager.instance.isGameover = true;
    }
}
