using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingManaging : MonoBehaviour
{

    public int num;


    public void GameQuit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(num);
    }


}
