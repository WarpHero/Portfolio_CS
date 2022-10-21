using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{

    public enum State
    {
        Idle, Move, Attack
    }

    public State state;
    public RawImage imgDamage;

    GameObject target;
    Player player;

    public ParticleSystem attackEffect;

    public float findDist=10f;
    public float attackDist = 5f;
    public float attackNearDist = 3f;
    public float attackTime = 2f;

    public float rollAmount, pitchAmount, yawAmount;
    public float rollValue, pitchValue, yawValue;

    public float timer;
    public float attackTimer;

    Vector3 rotateValue;
    int attackdamage=5;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player"); //player가 없으면 null반환
        player = target.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            timer += Time.deltaTime;
            attackTimer+=Time.deltaTime;

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

            if (state == State.Idle)
            {
                UpdateIdle();
                MoveintheSpace();
            }
            else if (state == State.Move)
            {
                UpdateMove();
            }
            else if (state == State.Attack)
            {
                UpdateAttack();
            }
        }
    }

    private void UpdateIdle()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, findDist))
        {
            if (hit.transform.CompareTag("Player"))
            {
                attackEffect.Stop();
                attackEffect.Play();
                imgDamage.enabled = true;
                state = State.Move;
            }
        }
    }

    private void UpdateMove()
    {
        float distance=Vector3.Distance(transform.position, target.transform.position);
        if (distance < attackDist&&distance>attackNearDist)
        {
            state = State.Attack;
            imgDamage.color = Color.yellow;
            if (attackTimer > attackTime)
            {
                attackEffect.Stop();
                attackEffect.Play();
                player.AddDamage(attackdamage);
                attackTimer = 0;
            }
        }
        
    }

    private void UpdateAttack()
    {
        Vector3 dir = target.transform.position - transform.position; //player와의 방향 구함
        dir.Normalize(); //길이 1로 맞춰줌
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < attackNearDist)
        {
            attackdamage = 10;
            imgDamage.color = Color.red;
            if (attackTimer > attackTime)
            {
                player.AddDamage(attackdamage);
                attackTimer = 0;
            }

        }

    }

    void MoveintheSpace()
    {
        rotateValue = new Vector3(pitchValue * pitchAmount,
                                 yawValue * yawAmount,
                                 rollValue * rollAmount);

        transform.Rotate(rotateValue * Time.deltaTime);
    }
}
