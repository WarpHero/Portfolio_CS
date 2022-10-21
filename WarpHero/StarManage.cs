using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManage : MonoBehaviour
{
    public GameObject prefab;
    public float time;
    public Transform[] point;

    void starCreate()
    {
        int i=Random.Range(0,point.Length);
        Instantiate(prefab, point[i]);
    }
    //사라진 장소에서 새롭게 별 생성되게 만드는 방법 어떻게 해야 할까?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
