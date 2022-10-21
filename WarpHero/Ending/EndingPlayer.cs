using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 2f;

    //public Camera mainCam;
    //public Camera endingCam;

    public RawImage imgVic;

    public AudioClip clipWalk;
    public AudioClip clipPunch;

    public GameObject nextStg;
    public GameObject nextBttn;

    Rigidbody rg;


    void pMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward;

            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            GetComponent<Animator>().SetBool("bMove", true);
            GetComponent<AudioSource>().PlayOneShot(clipWalk);

        }
        else
        {
            GetComponent<Animator>().SetBool("bMove", false);
        }

    }

    void pAttack()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            GetComponent<Animator>().SetBool("IsAttack", true);
            GetComponent<AudioSource>().PlayOneShot(clipPunch);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsAttack", false);

        }
    }

    void pVictory()
    {
        if (StageManager.score >= 30)
        {
            //NextStage로 넘어가기
            nextBttn.SetActive(true);
            nextStg.SetActive(true);

            //GetComponent<Animator>().SetTrigger("Victory");
            //승리포즈
            //imgVic.color = new Color(1, 1, 1, 1);
            //victory sign
            //
            //
            //GetComponent<Animator>().SetTrigger("VictoryDance");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // rg= GetComponent<Rigidbody>();
        //nextStg = GameObject.Find("SceneManager");
        //nextBttn = GameObject.Find("Next");

    }

    // Update is called once per frame
    void Update()
    {
        pMove();
        pAttack();
        pVictory();
    }
}