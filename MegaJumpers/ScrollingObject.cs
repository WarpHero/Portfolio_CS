using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }


        if (transform.position.x < -35f)
        {
            Destroy(gameObject);
        }
    }
}
