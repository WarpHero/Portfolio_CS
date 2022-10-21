using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public int max = 200;

    bool bDamage;
    public RawImage imgDamage;
    public RawImage imgBar;
    public Slider starSlider;

    public int StarScore;
    public AudioClip clipStar;

    Vector3 posRespawn;

    public int playerheart=3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            GetComponent<AudioSource>().PlayOneShot(clipStar);
            //Debug.Log("a");
            StarScore+=30;

            starSlider.value = StarScore;
        }
   
        else if (other.gameObject.CompareTag("Trap"))
        {
            hp -= 20;
        }
        //trap
    }


    public void Damage(int amount)
    {
        if (hp <= 0) return;

        hp -= amount;
        GetComponent<Animator>().SetTrigger("Hitted");
        GetComponent<Animator>().SetTrigger("GoIdle");
        bDamage = true;
        //imgBar.transform.localScale=new Vector3(hp/200.0f, 1, 1);


        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");

            GetComponent<PlayerMove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;

            playerheart--;
            //count++;

            if (playerheart > 0)
            {
                Invoke("Respawn", 2);
            }

        }
        

        
    }

    public void Respawn()
    {
        hp = 100;
        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");
        GetComponent<Animator>().SetTrigger("GoIdle");
        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;

        //imgBar.transform.localScale = new Vector3(hp / 200.0f, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = 200;
        //posRespawn = transform.position;
        posRespawn = new Vector3(0, 0, 0);
        //imgBar.transform.localScale = new Vector3(hp / 200.0f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        imgBar.transform.localScale = new Vector3(hp / 200.0f, 1, 1);
        if (hp >= max)
        {
            hp = max;
        }

        if (bDamage)
        {
            imgDamage.color=new Color(0, 0, 0, 1);
        }
        else
        {
            imgDamage.color=Color.Lerp(imgDamage.color, Color.clear, 5*Time.deltaTime);
        }

        bDamage = false;
    }
}

