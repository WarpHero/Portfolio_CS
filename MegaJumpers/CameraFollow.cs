using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            if (player.transform.position.y > 5.9f)
            {
                transform.position = new Vector2(0f, player.transform.position.y);
            }
            else
            {
                transform.position = Vector2.zero;
            }
        }

    }
}
