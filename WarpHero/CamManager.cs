using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    public Camera mainCam;
    public Camera endingCam;


    void Ending()
    {
        if (StageManager.score >= 150)
        {
            //mainCam.enabled = false;
            endingCam.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Ending();
    }
}
