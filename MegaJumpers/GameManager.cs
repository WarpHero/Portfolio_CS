using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover;
    public bool isNightmare;

    public bool bEasyClear;
    public bool bNormalClear;
    public bool bHardClear;
    

    int score = 0;
    int coin = 0;
    float timer;
    bool escape;

    private void Awake()
    {
        score = 0;
        coin = 0;

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        if (bEasyClear && bHardClear && bNormalClear) isNightmare = true;
        else isNightmare = false;

        if (Application.platform == RuntimePlatform.Android)
        {
            if (escape == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ShowAndroidToastMessage("뒤로가기 버튼을 한 번 더 누르시면 종료됩니다.");
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

    //public void AddScore(int newScore)
    //{
    //    score+=newScore;
    //    //scoreText.text = "SCORE : " + score;
    //}

    public int AddScore(int newScore)
    {
        score += newScore;
        return score;
    }

    public int AddCoin(int newCoin)
    {
        //if (coin <= -1) isGameover = true;

        coin += newCoin;
        //coinText.text = "X " + coin;
        return coin;
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        //gameoverText.SetActive(true);

        //GameoverUI.transform.DOMoveY(0f, 0.5f);
    }

    public void ResetPoint()
    {
        score = 0;
        coin = 0;
        Time.timeScale = 1;
    }


}
