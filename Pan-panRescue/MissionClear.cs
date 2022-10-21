using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissionClear : MonoBehaviour
{
    //EnemyMove[] le;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.AddScore > GameManager.instance.MaxScore)
        {
            //le = GameObject.FindObjectsOfType<EnemyMove>();
            //foreach (EnemyMove o in le)
            //{
            //    o.enabled = false;
            //}
            StartCoroutine(MComplete());

            GameManager.instance.ScoreReset();
        }
        
    }
    IEnumerator MComplete()
    {
        int oscill = 3;
        transform.DOLocalMoveY(0, 0.7f);
        for (int i = 0; i < 3; i++) {
            transform.DOLocalMoveY(oscill, 0.2f);
            yield return new WaitForEndOfFrame();
            oscill /= 2;
            transform.DOLocalMoveY(0, 0.1f).SetRelative();
        }
        //transform.DOLocalMoveY(0, 0.01f);
    }
}
