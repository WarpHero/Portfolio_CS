using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManaging : MonoBehaviour
{

    //pause, replay, gameover, gameQuit

    PlayerMove player;

    public GameObject pause;
    public GameObject replay;
    public GameObject gameover;

    public GameObject tutorial;

    public GameObject skip;

    public int num;

    public void GamePause()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        replay.SetActive(true);

    }

    public void GameRePlay()
    {
        Time.timeScale = 1;
        replay.SetActive(false);
        pause.SetActive(true);
    }


    public void GameQuit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(num);
    }

    public void GameStart()
    {
        tutorial.SetActive(false);
        Time.timeScale = 1;

    }

    private void Awake()
    {
        Debug.Log("aa");
        
        Time.timeScale = 0;
        Invoke("GameStart", 3f);



    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.hp <= 0)
        {
            player.enabled = false;
            gameover.SetActive(true);

        }
    }
}
