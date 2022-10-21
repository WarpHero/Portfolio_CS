using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public GameObject pause;

    RollingBG[] sc;


    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
        sc = FindObjectsOfType<RollingBG>();

        foreach (RollingBG level in sc)
        {
            level.enabled = false;
        }
    }
}
