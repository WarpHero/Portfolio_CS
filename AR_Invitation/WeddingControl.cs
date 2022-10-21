using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeddingControl : MonoBehaviour
{

    public List<GameObject> party;

    public List<GameObject> invitation;

    public float timer;

    public int i;

    public void ExitButton()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Weddingday());
    }

    IEnumerator Weddingday()
    {
        Debug.Log("weddingStart");
        yield return StartCoroutine(Weddingtimer());
        Debug.Log("weddingEnd");
    }

    IEnumerator Weddingtimer()
    {
        foreach(GameObject go in party)
        {
            if (party[i] != null)
            {
                Debug.Log("wedding" + i);
                party[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.7f);
                i++;
            }
        }
    }
    public void LinkURL()
    {
        Application.OpenURL("https://youtu.be/H8euXRCA8D4/");
    }

    private void Update()
    {
        timer+=Time.deltaTime;

        if (timer > 18f)
        {
            party[0].SetActive(false);
            invitation[0].SetActive(true);
        }
    }


}
