using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Image buttonStart;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        buttonStart = GetComponent<Image>();
        buttonStart.color = new Color(0, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BtnColor());

    }

    IEnumerator BtnColor()
    {
        while (true) {

            buttonStart.color = Color.Lerp(Color.white, buttonStart.color, 3 * Time.deltaTime);
            yield return new WaitForSeconds(2f);
            buttonStart.color = new Color(0, 1, 1, 1);
            buttonStart.color = Color.Lerp(buttonStart.color, Color.white, 3 * Time.deltaTime);
            yield return new WaitForSeconds(2f);

        }
    }
}
