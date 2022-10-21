using DG.Tweening;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] objBG;

    public GameObject[] clear;

    public int cnt;

    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (GameManager.instance.bEasyClear) clear[0].SetActive(true);
        if (GameManager.instance.bNormalClear) clear[1].SetActive(true);
        if (GameManager.instance.bHardClear) clear[2].SetActive(true);
    }

    public void NextnBT()
    {

        if (timer > 0.41f)
        {
            cnt++;
            foreach (GameObject go in obj)
            {
                //go.transform.position=new Vector3(go.transform.position.x-11, 0f, 0f);
                go.transform.DOLocalMoveX(-11, 0.3f).SetRelative();
                ChangeBG(cnt);
                if (go.transform.position.x < -21.9f)
                {
                    go.transform.position = new Vector3(22f, 0f, 0f);
                }

            }
        }
        timer = 0;
    }

    public void BackBT()
    {
        cnt--;
        if (timer > 0.41f)
        {
            foreach (GameObject go in obj)
            {
                //go.transform.position = new Vector3(go.transform.position.x + 11, 0f, 0f);
                go.transform.DOLocalMoveX(11, 0.3f).SetRelative();
                ChangeBG(cnt);
                if (go.transform.position.x > 21.9f)
                {
                    go.transform.position = new Vector3(-22f, 0f, 0f);
                }

            }
        }
        timer = 0;
    }

    public void ChangeBG(int num)
    {
        if (num < 0) { num *= -3; }
        int res = num % 4;
        if (res == 0)
        {
            foreach (GameObject go in objBG)
            {
                go.SetActive(false);
            }
            objBG[res].SetActive(true);
        }
        if (res == 1)
        {
            foreach (GameObject go in objBG)
            {
                go.SetActive(false);
            }
            objBG[res].SetActive(true);
        }
        if (res == 2)
        {
            foreach (GameObject go in objBG)
            {
                go.SetActive(false);
            }
            objBG[res].SetActive(true);
        }
        if (res == 3)
        {
            foreach (GameObject go in objBG)
            {
                go.SetActive(false);
            }
            objBG[res].SetActive(true);
        }
    }
}
