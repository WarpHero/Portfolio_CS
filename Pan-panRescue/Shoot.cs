using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject cam;
    public GameObject prefab;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!GameManager.instance.isGameover)
    //    {
    //        Fire();
    //    }
    //}

    public void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                //여기서 Enemy interface 사용하기
                Destroy(hit.transform.transform.gameObject);
                Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
                audio.Play();
            }
        }
    }
}
