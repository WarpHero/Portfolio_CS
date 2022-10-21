using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MainTitleCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainCharacterScale());
    }


    IEnumerator MainCharacterScale()
    {
        while (true)
        {
            transform.DOScale(1.2f, 2f);
            transform.DOShakePosition(0.5f, 0.8f);
            yield return new WaitForSeconds(0.5f);
            transform.DOScale(0.9f, 1.5f);
            transform.DOShakePosition(0.5f, 0.8f);
            yield return new WaitForSeconds(0.4f);
            transform.DOScale(1.5f, 1.2f);
            transform.DOShakePosition(0.5f, 0.8f);
            yield return new WaitForSeconds(0.3f);
            transform.DOScale(0.8f, 1f);
            transform.DOShakePosition(0.5f, 0.8f);
            yield return new WaitForSeconds(0.5f);

        }
    }

}
