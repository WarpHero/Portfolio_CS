using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroduceText : MonoBehaviour
{
    public GameObject[] IntroText;
    public GameObject MainText;
    public GameObject NextText;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject intro in IntroText)
        {
            intro.SetActive(false);
        }
        MainText.SetActive(true);
        NextText.SetActive(false);
        StartCoroutine(Intro());

    }

    IEnumerator Intro()
    {
        while (i < IntroText.Length)
        {
            yield return new WaitForSeconds(1.5f);
            IntroText[i].SetActive(true);
            i++;

        }
        yield return new WaitForSeconds(1.5f);

        MainText.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        NextText.SetActive(true);
    }
}
