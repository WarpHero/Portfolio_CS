using UnityEngine;
using DG.Tweening;
using TMPro;

public class SwipePanelMenu : MonoBehaviour
{
    public GameObject menuHandle;

   // public GameObject[] menuButton;

    AudioSource menuAudio;

    RectTransform rectTransform;
    Vector3 startPosition;
    Vector3 startpoint, endpoint;
    float startpointX, endpointX;
    float startpointY, endpointY;
    float rectdelta;
    float deltapointX;

    public bool isMenu;

    public TextMeshProUGUI text;
    public AudioClip soundopen;
    public AudioClip soundclosed;

    LivingEntity[] livingentity;

    // Start is called before the first frame update
    void Start()
    {
        isMenu = false;
        startPosition = transform.position;
        rectTransform = GetComponent<RectTransform>();
        rectdelta = rectTransform.sizeDelta.x;
        print(rectdelta = rectTransform.sizeDelta.x);

        menuAudio=GetComponent<AudioSource>();

        livingentity=GameObject.FindObjectsOfType<LivingEntity>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startpoint = touch.position;

                startpointX = startpoint.x;
                startpointY = startpoint.y;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                endpoint = touch.position;

                endpointX = endpoint.x;
                endpointY = endpoint.y;
            }

            deltapointX = endpointX - startpointX;

            text.text = "start " + startpointX +
                "\n end " + endpointX +
                "\n delta " + deltapointX;

            if (startpointX <= 70f &&
                startpointY > startPosition.y - (rectdelta / 2) &&
                startpointY < startPosition.y + (rectdelta / 2) &&
                deltapointX >= 100)
            {
                
                menuHandle.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
                menuAudio.PlayOneShot(soundopen);
                isMenu = true;
            }

            if (isMenu &&
                startpointX >= rectTransform.sizeDelta.x + 150f &&
                startpointX <= Screen.width * 0.9f&&
                deltapointX <= -150)
            {
                
                menuHandle.transform.DORotate(new Vector3(0, 0, -180f), 0.5f);
                menuAudio.PlayOneShot(soundclosed);
                isMenu = false;
            }
        }

        //if (isMenu)
        //{
        //    foreach(LivingEntity lv in livingentity)
        //    {
        //        Time.timeScale = 0f;
        //    }
        //}
        //else
        //{
        //    foreach (LivingEntity lv in livingentity)
        //    {
        //        Time.timeScale = 1f;
        //    }
        //}

        //if (isMenu)
        //{
        //    foreach(GameObject o in menuButton)
        //    {
        //        if (o != null)
        //        {
        //            o.SetActive(false);
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (GameObject o in menuButton)
        //    {
        //        o.SetActive(true);
        //    }
        //}
    }
}         