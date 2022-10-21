using DG.Tweening;
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;

    int jumpCnt = 0;
    bool isGrounded;
    bool isDead;
    bool isFevertime;

    Rigidbody2D rb;
    Animator anim;
    Vector2 startPos;

    public AudioClip Soundjump;
    public AudioClip Sounddead;
    public AudioClip SoundDiamond;
    public AudioClip Soundstar;

    public GameObject[] stars=new GameObject[2];


    GameObject coin;


    AudioSource soundBG;

    SpriteRenderer sp;

    LevelMaster lm;
    LMNormal levelnormal;
    LMHard levelhard;

    int rescoin;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundBG = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        coin = transform.Find("GetScore").gameObject;
        lm = FindObjectOfType<LevelMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && !isDead)
        {
            Die();
        }

        if (collision.CompareTag("Coin") && !isDead)
        {

            coin.SetActive(true);
        }

        if (collision.CompareTag("Diamond") && !isDead)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundDiamond);
            collision.gameObject.SetActive(false);
            stars[0].SetActive(true);
            stars[1].SetActive(true);

            isFevertime = true;

            StartCoroutine(PlayerFever());
        }
        if (collision.CompareTag("Star") && !isDead)
        {
            GetComponent<AudioSource>().PlayOneShot(Soundstar);
        }
        if(collision.CompareTag("Saw") && !isDead&&!isFevertime)
        {
            rescoin=GameManager.instance.AddCoin(-10);
            if(rescoin<=-1) Die();

            StartCoroutine(PlayerSaw());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCnt = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0) && jumpCnt < 2)
        {
            jumpCnt++;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
            GetComponent<AudioSource>().PlayOneShot(Soundjump);

        }
        else if (Input.GetMouseButtonUp(0) && rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity * 0.5f;
        }

        anim.SetBool("Grounded", isGrounded);

        if (transform.position.y > 6.0f)
        {
            transform.position = new Vector2(transform.position.x, 5.9f);
        }

        if (transform.position.x <= -4.4f || transform.position.x >= -4.6f)
        {
            transform.position = new Vector2(-4.5f, transform.position.y);
        }


    }

    IEnumerator PlayerFever()
    { //¾à 3ÃÊ
        isFevertime = true;
        anim.SetBool("isFever", isFevertime);
        Time.timeScale = 1.5f;
        for (int i = 30; i > 0; i--)
        {
            if (i % 2 == 0) { transform.DOMoveY(3f, 0.2f).SetRelative(); }
            else { transform.DOMoveY(-3f, 0.2f).SetRelative(); }
            //sp.enabled = false;
            sp.color = Color.red;
            //transform.DOMoveY(3f, 0.1f).SetRelative();
            yield return new WaitForSeconds(0.08f);
            //sp.enabled = true;
            sp.color = Color.white;
            //transform.DOMoveY(-3f, 0.1f).SetRelative();
            yield return new WaitForSeconds(0.07f);
        }
        //yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        isFevertime = false;
        anim.SetBool("isFever", isFevertime);
        transform.Translate(-4.5f, 1f, 0);
        jumpCnt = 0;
        //stars.SetActive(false);



    }

    IEnumerator PlayerSaw()
    {
        Time.timeScale = 0.7f;
       for(int i=0;i<10; i++)
        {
            sp.enabled = false;
            yield return new WaitForSeconds(0.08f);
            sp.enabled = true;
            yield return new WaitForSeconds(0.08f);
        }
        Time.timeScale = 1f;

    }


    void Die()
    {
        anim.SetTrigger("Die");
        soundBG.Pause();
        GetComponent<AudioSource>().PlayOneShot(Sounddead);
        rb.velocity = Vector2.zero;
        isDead = true;
        if (transform.position.y <= 0f)
        {
            transform.DOMoveY(15f, 0.7f).SetRelative();
            transform.DOMoveY(-6f, 0.2f).SetRelative();
        }
        else
        {
            transform.DOMoveY(1f, 0.7f).SetRelative();
            transform.DOMoveY(-6f, 0.2f);
        }
        StartCoroutine(Dead()); //after character anim done
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1f);
        anim.enabled = false;
        GameManager.instance.OnPlayerDead();
        lm.OnPlayerDeadinLevel();
     
    }
}
