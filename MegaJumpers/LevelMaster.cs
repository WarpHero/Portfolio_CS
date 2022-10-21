using DG.Tweening;
using TMPro;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public GameObject gameoverText;
    public GameObject GameoverUI;

    public AudioClip GameoverBG;

    public static bool bEndGame;


    AudioSource musicBG;

    int score;
    int coin;
    string s_coin;

    private void Start()
    {
        musicBG = GetComponent<AudioSource>();
        bEndGame = false;
    }
    public void PrintScore(int newScore)
    {
        score = GameManager.instance.AddScore(newScore);
        scoreText.text = "Score : " + score;
    }

    public void PrintCoin(int newCoin)
    {
        coin = GameManager.instance.AddCoin(newCoin);

        if (coin > 9999) GameManager.instance.isNightmare = true;

        if (coin > 99) s_coin = coin.ToString();
        else if (coin > 9) s_coin = "0" + coin.ToString();
        else s_coin = "00" + coin.ToString();

        coinText.text = "X " + s_coin;
    }

    public void OnPlayerDeadinLevel()
    {
        //musicBG.clip = GameoverBG;
        musicBG.Stop();

        gameoverText.SetActive(true);

        GameoverUI.transform.DOMoveY(0f, 0.5f);

        bEndGame = true;
        
    }

}
