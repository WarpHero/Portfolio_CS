using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManage : MonoBehaviour
{
    GameObject musicBG;
    GameObject musicVictory;

    public AudioSource BGAudio;
    public AudioSource victoryAudio;
    bool check;
    void EndingMusic()
    {
        if (StageManager.score >= 150)
        {
            check = true;
            BGAudio.Stop();
            victoryAudio.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
     /*   musicBG = GameObject.Find("BGMusic");
        musicVictory = GameObject.Find("VictoryMusic");

        BGAudio = musicBG.GetComponent<AudioSource>();
        victoryAudio = musicVictory.GetComponent<AudioSource>();
     */
    }

    // Update is called once per frame
    void Update()
    {
        if(check == false)
        EndingMusic();  
    }
}
