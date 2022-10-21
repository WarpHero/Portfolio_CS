using UnityEngine;

public class PlatformSpawnerEasy : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject item;
    //public int count;

    int[] yPos = { 1, 0, 1, 2, 2, 0, -1, 2, 0, 1, 1, -1, 0, 0, 1, -1, 2 };
    public int i, j;
    float xPos = 20f;
    public float timer;
    Vector2 poolPosition = new Vector2(0, -25);
    GameObject[] platform;
    GameObject items;



    // Start is called before the first frame update
    void Start()
    {
        platform = new GameObject[platformPrefab.Length];
        for (int i = 0; i < platformPrefab.Length; i++)
        {
            platform[i] = Instantiate(platformPrefab[i], poolPosition, Quaternion.identity);
        }
        items = Instantiate(item, poolPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager.instance.isGameover) return;

        if (timer > 2f)
        {
            timer = 0;
            platform[i].transform.position = new Vector2(xPos, yPos[j]);
            platform[i].gameObject.SetActive(true);

            i++;
            j++;

        }

        if (j % 15 == 0)
        {
            items.transform.position = new Vector2(xPos, yPos[j] + 1.5f);
            items.gameObject.SetActive(true);

        }

        if (i >= platformPrefab.Length) i = 0;
        if (j >= yPos.Length) j %= yPos.Length;

        if (items.transform.position.x < -10f)
        {
            items.transform.position = poolPosition;
            items.SetActive(false);
        }
    }
}
