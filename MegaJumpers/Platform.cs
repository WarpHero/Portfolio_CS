using UnityEngine;

public class Platform : MonoBehaviour
{
    int score;
    bool stepped;

    GameObject player;
    Collider2D col;
    LevelMaster lm;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<Collider2D>();
        score = 10;

        //
        lm = FindObjectOfType<LevelMaster>();
    }

    private void OnEnable()
    {
        stepped = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            stepped = true;
            //GameManager.instance.AddScore(score);
            lm.PrintScore(score);
        }
    }

    private void Update()
    {
        if ((player.transform.position.y <= transform.position.y - 0.2f) &&
            transform.position.x - player.transform.position.x < 5f)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }

        if (transform.position.x < -20f)
        {
            this.gameObject.SetActive(false);
        }
    }

}
