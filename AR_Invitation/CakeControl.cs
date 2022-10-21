using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeControl : MonoBehaviour
{

    public List<GameObject> cakeobj;

    public float timer;

    public int i;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cake());
    }

    IEnumerator Cake()
    {
        Debug.Log("Start");
        yield return StartCoroutine(CakeTimer());
        Debug.Log("End");
    }
    IEnumerator CakeTimer()
    {
        foreach(GameObject obj in cakeobj)
        {
            if (cakeobj[i] != null)
            {
                Debug.Log(i);
                cakeobj[i].SetActive(true);
                yield return new WaitForSeconds(2f);
                i++;
            }
            
        }

        //yield return new WaitUntil(()=> i<cakeobj.Count);
        

        //yield return new WaitForSeconds(2f);
       
    }

    // Update is called once per frame
    void Update()
    {
       timer+=Time.deltaTime;


    }
}
