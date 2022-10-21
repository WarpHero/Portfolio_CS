using UnityEngine;

public class PlatformSpawnerHard : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject item;
    //public int count;

    float[] yPos = { 1, 2.7f, 1.89f, 2.32f, 1.75f, 2.1f, 1.43f, 3.12f, 1.85f, 0, 2.21f, 1.48f, 1.9f, 2.7f };
    float[] yPos2 = { -1f, -1.2f, -2f, -2.7f, -1.9f, -2.1f, -3.1f, -2.24f };
    public int i, j, k;
    float xPos = 20f;
    public float timer;
    public float timer2;
    Vector2 poolPosition = new Vector2(0, -25);
    GameObject[] platform;
    GameObject items;

    ScrollingObject[] so;

    // Start is called before the first frame update
    void Start()
    {
        i = j = 0;
        platform = new GameObject[platformPrefab.Length];
        for (int i = 0; i < platformPrefab.Length; i++)
        {
            platform[i] = Instantiate(platformPrefab[i], poolPosition, Quaternion.identity);
        }
        items = Instantiate(item, poolPosition, Quaternion.identity);

        so = FindObjectsOfType<ScrollingObject>();
        foreach(ScrollingObject item in so)
        {
            item.speed += 1.5f;
        }

        for (int i=0; i<platformPrefab.Length;i++)
        {
            if (i % 2 != 0) { so[i].speed += 1f; }
            else so[i].speed += 2f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer2+=Time.deltaTime;
        if (GameManager.instance.isGameover) return;

        if (timer > 3.9f)
        {
            timer = 0;
            platform[i].transform.position = new Vector2(xPos, yPos[j]);
            platform[i].gameObject.SetActive(true);

            i++;
            j++;

        }

        if (timer2 > 1.8f)
        {
            timer2 = 0;
            platform[i].transform.position=new Vector2(xPos, yPos2[k]);
            platform[i].gameObject.SetActive(true);
            i++;
            k++;
        }


        if (j % 5 == 0&&j!=0)
        {
            items.transform.position = new Vector2(xPos, yPos[j] + 1.5f);
            items.gameObject.SetActive(true);

        }

        if (i >= platformPrefab.Length) i = 0;
        if (j >= yPos.Length) j %= yPos.Length;
        if (k >= yPos2.Length) k %= yPos2.Length;

        if (items.transform.position.x < -10f)
        {
            items.transform.position = poolPosition;
            items.SetActive(false);
        }
    }
}
