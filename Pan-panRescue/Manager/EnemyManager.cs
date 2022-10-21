using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//TODO: EnemySpawn�� ���ش�.
public class EnemyManager : SingletonManager<EnemyManager>
{
    //start�� �ڷ�ƾ���� ������ֱ� ���ؼ� manager  ��� �� ����?

    int count;
    public int maxCount=3;

    public List<GameObject> enemyPrefab;
    public float createTime = 2f;

    int levelupScore = 1000;

    public int EnemyCount
    {
        get { return count; }
        set 
        { 
            count = value;

            if(count<0) count=0;

            if(count>maxCount) count=maxCount;
        }
    }

   
    IEnumerator Start() //�ڵ����� �ڷ�ƾ ����
    {
        while (true)
        {
            int i=Random.Range(0, EnemyCount);

            if (count < maxCount)
            {
                GameObject enemy;
                Vector3 spawnPosition=this.transform.position+new Vector3(Random.value*5, 3, Random.value * 5);
                if (GameManager.instance.AddScore < levelupScore)
                {
                     enemy= Instantiate(enemyPrefab[i]);
                }
                else
                {
                   enemy = Instantiate(enemyPrefab[i]);
                    enemy.transform.rotation=transform.rotation;
                }
                enemy.transform.position = spawnPosition;

                count++;
            }

            //yield return new WaitForSeconds(createTime);
            yield return new WaitForSecondsRealtime(createTime);
        }
    }

}
