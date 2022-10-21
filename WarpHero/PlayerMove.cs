using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 2f;

    //public Camera mainCam;
    //public Camera endingCam;

   

    public AudioClip clipWalk;
    public AudioClip clipPunch;

   

    Rigidbody rg;


    void pMove()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal"); //화면터치 입력
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");


        if (h != 0 || v != 0)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward;
            //Vector3 dir = h1 * Vector3.right + v1 * Vector3.forward;

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
        if (Input.GetKey(KeyCode.Space)|| CrossPlatformInputManager.GetButton("Attack"))
        {

            GetComponent<Animator>().SetBool("IsAttack", true);
            GetComponent<AudioSource>().PlayOneShot(clipPunch);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsAttack", false);

        }
    }

    

    // Start is called before the first frame update
    void Start()
    {

        //DontDestroyOnLoad(gameObject);
        // rg= GetComponent<Rigidbody>();
        //nextStg = GameObject.Find("SceneManager");
        //nextBttn = GameObject.Find("Next");

    }
    
       // Update is called once per frame
    void Update()
    {
        pMove();
        pAttack();
        
    }
}
