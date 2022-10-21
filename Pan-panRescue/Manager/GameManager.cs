using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//SingleToneMananger 상속
public class GameManager : SingletonManager<GameManager>
{
    Player player;
    Enemy enemy;

    public bool isGameover;
    public bool isUpgradWeapon;


    int score;
    int maxScore=200; //1000
    float timer;
    bool escape;
    
    public int MaxScore { get { return maxScore; } }
    public int AddScore
    {
        
        get { return score; }

        set
        {
            score = value;
            
            if(score>500) isUpgradWeapon = true;
        }
    }
    
    public void ScoreReset() //scoreReset처리 어떻게 하는 것이 더 나은가?
    {

        score = 0;
        //get { return score; }

        //protected set
        //{
        //    score = 0;
        //}
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        isGameover = false;
        isUpgradWeapon = false;
    }
  
    void Start()
    {
        
        //scorereset property를 사용하는 것이 더 나은가?
        //아니면 event처리를 하는 것이 더 나은가?
        
        enemy = FindObjectOfType<Enemy>();
        
    }
    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnDeath += () => isGameover = true; //OnDeath에 event추가

            //player.OnDeath += () => ScoreReset;
        }

    }

    void Update()
    {
       GameQuit();

        
    
    }


    void GameQuit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (escape == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ShowAndroidToastMessage("뒤로 가기 버튼을 두번 누르면 종료됩니다.");
                    escape = true;
                    timer = 0f;
                }
            }
            else // escape == true
            {
                timer += Time.deltaTime;

                if (timer > 3f)
                {
                    escape = false;
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
        }
    }
    private void ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }


   public void GameQuitFunction()
    {
        Application.Quit();
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void GamePause()
    {
        //EnemyManager.instance.enabled = false;
        Time.timeScale = 0f;
    }

    public void GameRetry()
    {
        //EnemyManager.instance.enabled = true;
        Time.timeScale = 1f;
        
    }

}
