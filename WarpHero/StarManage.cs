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
    //����� ��ҿ��� ���Ӱ� �� �����ǰ� ����� ��� ��� �ؾ� �ұ�?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
