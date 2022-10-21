using UnityEngine;

public class DiaFever : MonoBehaviour
{

    public float speed = 5f;
    private void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
