using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject levelSetting;
    float startPosition;
    float timer;
    bool escape;

    public bool b;

    RollingBG[] sc;
    ScrollingObject[] sco;


    // Start is called before the first frame update
    void Start()
    {
        levelSetting = GameObject.Find("Setting");
        sc = FindObjectsOfType<RollingBG>();
        sco = FindObjectsOfType<ScrollingObject>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Pause()
    {

        levelSetting.transform.DOLocalMoveY(0f, 0.5f);
        foreach (RollingBG level in sc)
        {
            level.enabled = false;
        }
        foreach (ScrollingObject level in sco)
        {
            level.enabled = false;
        }

    }
    public void Retry()
    {
        if (!GameManager.instance.isGameover)
        {
            levelSetting.transform.DOLocalMoveY(1500f, 0.5f);

            foreach (RollingBG level in sc)
            {
                level.enabled = true;
            }
            foreach (ScrollingObject level in sco)
            {
                level.enabled = true;
            }

        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }
    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
        GameManager.instance.isGameover = false;
    }
}
