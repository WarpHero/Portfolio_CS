using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAircraftMoving : MonoBehaviour
{

    public float rollAmount, pitchAmount, yawAmount;
    public float rollValue, pitchValue, yawValue;
    public float timer;
    Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            rollAmount = UnityEngine.Random.Range(-10f, 10f);
            pitchAmount = UnityEngine.Random.Range(-10f, 10f);
            yawAmount = UnityEngine.Random.Range(-10f, 10f);

            rollValue = UnityEngine.Random.Range(0, 10);
            yawValue = UnityEngine.Random.Range(0, 10);
            pitchValue = UnityEngine.Random.Range(0, 10);
            timer = 0;
        }
        MoveintheSpace();
    }

    void MoveintheSpace()
    {
        rotateValue = new Vector3(pitchValue * pitchAmount,
                                 yawValue * yawAmount,
                                 rollValue * rollAmount);

        transform.Rotate(rotateValue * Time.deltaTime);
    }

}
