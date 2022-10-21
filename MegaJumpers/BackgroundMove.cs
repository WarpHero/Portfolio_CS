using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float time;

    [Header("Layer Setting")]
    public float[] Layer_Speed;
    public List<GameObject> Layer_Obj = new List<GameObject>();



    Transform _Maincam;
    float[] startPos = new float[7];
    float[] boundSizeX;
    float sizeX;

    // Start is called before the first frame update
    void Start()
    {
        _Maincam = Camera.main.transform;
        for (int i = 0; i < Layer_Speed.Length; i++)
        {
            boundSizeX[i] = Layer_Obj[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Layer_Obj[0].transform.position += Vector3.left * Time.deltaTime * Layer_Speed[0];

        for (int i = 1; i < Layer_Speed.Length; i++)
        {
            Layer_Obj[i].transform.position = new Vector2(Layer_Obj[0].transform.position.x * Layer_Speed[i], _Maincam.position.y);


        }
    }
}
