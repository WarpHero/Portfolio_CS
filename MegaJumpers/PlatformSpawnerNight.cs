using UnityEngine;

public class PlatformSpawnerNight : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject item;
    public GameObject deco;
    public GameObject enemy;
    
    [Header("--Timer--")]
    float yPos1Min = -3.5f;
    float yPos1Max = 0f;
    float yPos2Min = -1f;
    float yPos2Max = 3f;
    float xPos = 20f;
    public int i, j, k;
    public float timer;
    public float timer2;
    public float timer3;
    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    float timeBetSpawn;
    float lastSpawnTime;

    Vector2 poolPosition = new Vector2(0, -25);
    GameObject[] platform;
    GameObject items;
    GameObject decos;
    GameObject enemies;

    ScrollingObject[] so;

    // Start is called before the first frame update
    void Start()
    {
        i = j = k= 0;

        platform = new GameObject[platformPrefab.Length];

        for (int i = 0; i < platformPrefab.Length; i++)
        {
            platform[i] = Instantiate(platformPrefab[i], poolPosition, Quaternion.identity);
        }
        
        items = Instantiate(item, poolPosition, Quaternion.identity);
        decos = Instantiate(deco, poolPosition, Quaternion.identity);
        enemies = Instantiate(enemy, poolPosition, Quaternion.identity);

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;

        so = FindObjectsOfType<ScrollingObject>();
        foreach(ScrollingObject item in so)
        {
            item.speed += 0.5f;
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
        timer3+=Time.deltaTime;

        if (GameManager.instance.isGameover) return;


        if (timer > timeBetSpawn)
        {
            timer = 0;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yPos1Min, yPos1Max);
            platform[i].transform.position = new Vector2(xPos, yPos);
            platform[i].gameObject.SetActive(true);
            i++;
            j = Random.Range(1, 11);
            k = Random.Range(1, 11);

        }

        if (timer2 > timeBetSpawn)
        {
            timer2 = 0;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yPos2Min, yPos2Max);
            platform[i].transform.position = new Vector2(xPos, yPos);
            platform[i].gameObject.SetActive(true);
            i++;
            j = Random.Range(1, 11);
            k = Random.Range(1, 11);
        }
       
        if (j % 7 == 0&&j!=0)
        {
            float yPos=Random.Range(yPos1Min, yPos2Max);
            items.transform.position = new Vector2(xPos, yPos);
            items.gameObject.SetActive(true);
            //j = 0;
        }
        if (k % 4 == 0)
        {
            float yPos=Random.Range(yPos1Max, yPos2Max);
            decos.transform.position=new Vector2(xPos, yPos);
            decos.gameObject.SetActive(true);
            //k = 0;
        }
        
        if (k % 3 == 0)
        {
            float yPos = Random.Range(yPos1Min, yPos2Max);
            enemies.transform.position = new Vector2(xPos, yPos);
            enemies.gameObject.SetActive(true);
            //k = 0;
        }

        if (i >= platformPrefab.Length) i = 0;
        

        if (items.transform.position.x < -10f)
        {
            items.transform.position = poolPosition;
            items.SetActive(false);
        }
        if (decos.transform.position.x < -10f)
        {
            decos.transform.position = poolPosition;
            decos.SetActive(false);
        }
        if (enemies.transform.position.x < -10f)
        {
            enemies.transform.position = poolPosition;
            enemies.SetActive(false);
        }

        if (timer3 > 20f)
        {
            foreach (ScrollingObject item in so)
            {
                item.speed += 0.5f;
            }
            timer3 = 0;
        }
    }
}
