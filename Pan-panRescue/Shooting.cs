using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Shooting : MonoBehaviour
{
    Player player;
    Camera cam;
    LayerMask enemyMask;
    int damage = 70;
    bool isweaponchaned;
    bool vibe;
    AudioSource audioSource;

    public GameObject particlePos;
    public ParticleSystem[] fireImpact; //[0]발사할 때, [1]타겟에 맞았을 때.
    public List<GameObject> weapons1 = new List<GameObject>();
    public List<GameObject> weapons2 = new List<GameObject>();
    public AudioClip[] audioshooting;
    
    public TextMeshProUGUI enemyinfo;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        player.OnDeath += () => isweaponchaned = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        cam = Camera.main;
        enemyMask = LayerMask.GetMask("Enemy");

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (!GameManager.instance.isGameover)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, enemyMask))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    Enemy enemy = FindObjectOfType<Enemy>();
                    //enemy.AddDamage(damage);
                    enemyinfo.text = "HP: " + enemy.HP + "/" + enemy.maxHP;
                    //enemyinfo.text = "Enemy\n" + "HP: " + enemy.HP + "/" + enemy.maxHP;
                    //enemyinfo.text = "hello";


                }
                else
                {
                    enemyinfo.text = "No Target";
                }
            }

            if (GameManager.instance.isUpgradWeapon) { isweaponchaned = true; vibe = true; }

            if (isweaponchaned)
            {
                if (vibe)
                {
                    Handheld.Vibrate();
                    vibe = false;
                }
                WeaponChanging();
                //isweaponchaned = false;
            }
           
        }
        else
        {
            enemyinfo.text = "YOU LOSE";
        }

    }

    public void Shoot() //particle 재생 제대로 안 되는 문제 발생
    {
        if (!GameManager.instance.isGameover)
        {
            if(GameManager.instance.AddScore>500) audioSource.PlayOneShot(audioshooting[0]);
            else audioSource.PlayOneShot(audioshooting[1]);


            fireImpact[0].transform.position = particlePos.transform.position;
            fireImpact[0].Stop();
            fireImpact[0].Play();
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            RaycastHit hitinfo;
            if(Physics.Raycast(ray, out hitinfo))
            {
                if (hitinfo.transform.CompareTag("Enemy"))
                {

                    fireImpact[1].transform.position = hitinfo.point;
                    fireImpact[1].Stop();
                    fireImpact[1].Play();
                    fireImpact[1].transform.forward = hitinfo.normal;

                    Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
                    if(enemy!=null) enemy.AddDamage(damage);

                }
                
            }
        }
        
    }

    void WeaponChanging()
    {
        foreach (GameObject weapon in weapons1)
        {
            weapon.SetActive(false);
        }
        foreach (GameObject weapon in weapons2)
        {
            weapon.SetActive(true);
        }
        //damage += 10;
        damage = 100;
        //isweaponchaned = false;
        GameManager.instance.isUpgradWeapon = false;
    }
}
