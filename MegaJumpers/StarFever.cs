using UnityEngine;

public class StarFever : MonoBehaviour
{
    CircleCollider2D starCol;
    Collider2D col;
    float radius;
    Vector2 startPos;
    LevelMaster lm;
    public float speed;

    private void Awake()
    {
        startPos = transform.position;
        starCol = GetComponent<CircleCollider2D>();
        radius = starCol.radius;
        lm=FindObjectOfType<LevelMaster>();
    }
    private void OnEnable()
    {
        //col = Physics2D.OverlapCircle(transform.position, radius);
        //if (col.name == "Platform_02" || col.name == "Platform_03" || col.name == "Coin")
        //{
        //    this.gameObject.SetActive(false);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GameManager.instance.AddCoin(1);
            lm.PrintCoin(1);
            this.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover) return;

        if (transform.position.y < -20f||transform.position.y>20)
        {
            transform.position = startPos;
            this.gameObject.SetActive(false);

        }
        //if (!GameManager.instance.isGameover)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
    }
}
