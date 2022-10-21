using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneMove : MonoBehaviour
{

    public int sceneNum;
    public Button moveButton;
    //public TextMeshProUGUI countTxt;

    //int cnt=3;

    public float time;

    //public void Counting()
    //{
    //    countTxt.text = "" + cnt + "";

    //    cnt--;
    //}
    
    public void LoadStageScene()
    {

        //if (cnt<=0)
        //{
        //Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
        
        //}
    }public void LoadMainScene()
    {

        //if (cnt<=0)
        //{
        //Time.timeScale = 1;
        Debug.Log("1");
        SceneManager.LoadScene(0);
        
        //}
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;

    }
}
