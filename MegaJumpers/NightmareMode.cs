using UnityEngine;

public class NightmareMode : MonoBehaviour
{
    public GameObject[] nightmare;


    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.isNightmare)
        {
            return;
        }
        else
        {
            nightmare[0].SetActive(true);
            nightmare[1].SetActive(false);
        }

    }
}
