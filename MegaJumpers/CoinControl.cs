using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public GameObject particle;

    LevelMaster lm;

    int coincount = 1;

    private void Start()
    {
        lm = FindObjectOfType<LevelMaster>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameManager.instance.AddCoin(1);
            lm.PrintCoin(coincount);
            particle.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
