using UnityEngine;

public class PlatformSetting : MonoBehaviour
{
    public GameObject[] child = new GameObject[2];
    private void OnEnable()
    {
        child[0].SetActive(false);
        child[1].SetActive(true);
    }
}
