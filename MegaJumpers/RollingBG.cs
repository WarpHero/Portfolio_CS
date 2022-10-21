using UnityEngine;

public class RollingBG : MonoBehaviour
{
    public float Speed = 1f;

    float sizeX;
    float boundSizeX;

    // Start is called before the first frame update
    void Start()
    {
        sizeX = transform.parent.localScale.x;
        boundSizeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover) return;


        if (!GameManager.instance.isGameover)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;

            if (transform.position.x <= -boundSizeX * sizeX)
            {
                transform.position = new Vector2(transform.position.x + boundSizeX * sizeX * 2f, transform.position.y);
            }
        }

    }
}
