using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//SingleToneMananger ���
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
    
    public void ScoreReset() //scoreResetó�� ��� �ϴ� ���� �� ������?
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
        
        //scorereset property�� ����ϴ� ���� �� ������?
        //�ƴϸ� eventó���� �ϴ� ���� �� ������?
        
        enemy = FindObjectOfType<Enemy>();
        
    }
    private void OnEnable()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnDeath += () => isGameover = true; //OnDeath�� event�߰�

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
                    ShowAndroidToastMessage("�ڷ� ���� ��ư�� �ι� ������ ����˴ϴ�.");
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
