using UnityEngine;

public class EnableStars : MonoBehaviour
{
    public GameObject[] stars;

    public float speedV;
    public float speedH;

    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void OnEnable()
    {

        foreach (GameObject go in stars)
        {
            go.SetActive(true);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left*speedV*Time.deltaTime+ Vector2.up*speedH*Time.deltaTime);

        if (transform.position.y < -10f || transform.position.y > 10)
        {
            transform.position = startPos;
            this.gameObject.SetActive(false);

        }
    }
}
