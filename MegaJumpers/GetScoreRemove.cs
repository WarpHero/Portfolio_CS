using UnityEngine;

public class GetScoreRemove : MonoBehaviour
{
    float timer;
    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.3f)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
