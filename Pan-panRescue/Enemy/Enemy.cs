using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    MeshRenderer mesh;
    public GameObject realEnemy;
    public AudioClip audioDeath;


    public override void OnEnable()
    {
        maxHP = Random.Range(100, 150);
        //OnDeath += () => GameManager.instance.AddScore += (maxHP-70); //점수가 기하급수적으로 증가하는 문제
        //OnDeath += () => EnemyManager.instance.EnemyCount -= 1;
        base.OnEnable();
        //mesh = GetComponent<MeshRenderer>();
        mesh=realEnemy.GetComponentInChildren<MeshRenderer>();
    }
    public override void Die()
    {
        base.Die();
        audiosource.PlayOneShot(audioDeath);
        //GameManager.instance.AddScore += (maxHP - 70);
        GameManager.instance.AddScore=100;
        EnemyManager.instance.EnemyCount -= 1;
        //this.gameObject.SetActive(false);
        Destroy(gameObject, 0.3f);
    }

    public override void ActionDamage()
    {
        base.ActionDamage();
        StartCoroutine(DamageableAction());
    }

    IEnumerator DamageableAction()
    {
        for (int i = 0; i < 3; i++) {
            mesh.enabled = false;
            yield return new WaitForSeconds(0.03f);
            mesh.enabled = true;
            yield return new WaitForSeconds(0.03f);
        }

    }
}
