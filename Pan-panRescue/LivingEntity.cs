using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivingEntity : MonoBehaviour, IDamageable
{
    int hp;
    public int maxHP=100;
    public Slider sliderHP;
    public event Action OnDeath;

    protected AudioSource audiosource;
    public AudioClip audioDamage;
    //public AudioClip audioDeath;

    //property
    public bool dead { get; protected set; }

    public int HP
    {
        get { return hp; }
        protected set
        {
            hp = value;
            sliderHP.value = value;

            if(hp<=0) hp = 0;
            if(hp>maxHP) hp = maxHP;

        }
    }

    //AddDamage : damage�� ����
    public virtual void AddDamage(int damage)
    {
        //SetHP(GetHP() - 1);
        HP -= damage; //�ڵ����� set=get-1 ȣ���
        ActionDamage();

        if(HP <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (OnDeath != null)
        {
            OnDeath();
        }
        
        dead =true;
    }

    //ActionDamage : �� ��ü�� damage�� �Ծ��� �� ���̴� �ൿ�̳� ȿ��
    public virtual void ActionDamage()
    {
        audiosource.PlayOneShot(audioDamage);
    }

    public virtual void OnEnable()
    {
        dead = false;
        HP = maxHP;
        sliderHP.maxValue = maxHP;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        sliderHP.maxValue = maxHP;
        //SetHP(maxHP);
        HP = maxHP;
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            HP = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

}