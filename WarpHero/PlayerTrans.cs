using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrans : MonoBehaviour
{
    public Transform[] transPos;
    public bool bIn;

    int i;
    float time;

    public AudioClip clipWarp;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Warp"))
        {
            bIn = true;
        }
    }

    void Warp()
    {

        int i=Random.Range(0, transPos.Length);

        GetComponent<AudioSource>().PlayOneShot(clipWarp);

        transform.position = transPos[i].position;
        bIn = false;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        bIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (transform.position.y < -10)
        {
            bIn=true;
        }
        
        if (bIn&&time>3f)
        {
            Warp();
            bIn = false;
        }
    }
}
