using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    float atkTime;
    LineRenderer line;
    Transform atkPoint;

    //public AudioClip clipPunch;

    //public GameObject magic;

    public int amount=50;
    void Attack()
    {

        //// ???? ???? ???? ????
        //GameObject magicAttack=Instantiate(magic);
        //Vector3 magicPos=transform.position;

        //magicPos.y=transform.position.y+2;

        //magicAttack.transform.position=magicPos;
        //magicAttack.GetComponent<Rigidbody>().AddForce(3*Vector3.up);

        //Instantiate(magic, atkPoint.transform.position, atkPoint.transform.rotation);

        ////
        Ray ray=new Ray(atkPoint.position,atkPoint.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 2, LayerMask.GetMask("Attackable"))){

            EnemyHealth e=hit.collider.GetComponent<EnemyHealth>();

            if (e != null)
            {
                
                e.Damage(amount);
            }
            line.enabled = true;

            line.SetPosition(0, atkPoint.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.enabled = true;
            line.SetPosition(0, atkPoint.position);
            line.SetPosition(1, atkPoint.position+ray.direction*2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        line= GetComponent<LineRenderer>();
        atkPoint = transform.Find("AtkPoint");
    }

    // Update is called once per frame
    void Update()
    {
        atkTime += Time.deltaTime;

        if ((Input.GetKey(KeyCode.Space)|| CrossPlatformInputManager.GetButton("Attack")) && atkTime>=0.2f)
        {//CrossPlatformInputManager.GetButton("Attack")
            atkTime = 0;
            

            //GetComponent<AudioSource>().PlayOneShot(clipPunch);
            Attack();
        }

        if (atkTime > 0.05f)
        {
            line.enabled = false;
        }
    }
}
