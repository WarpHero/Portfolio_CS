using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Track : MonoBehaviour
{

    public ARTrackedImageManager manager;
    
    public List<GameObject> list1 = new List<GameObject>();
    Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    public List<AudioClip> list2 = new List<AudioClip>();
    Dictionary<string, AudioClip> dict2 = new Dictionary<string, AudioClip>();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject o in list1)
        {
            dict1.Add(o.name, o);
        }

        foreach(AudioClip o in list2)
        {
            dict2.Add(o.name, o);
        }
    }


    private void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage t in eventArgs.added)
        {
            UpdateImage(t);
            UpdateSound(t);
        }

        foreach (ARTrackedImage t in eventArgs.updated)
        {
            UpdateImage(t);
        }
    }

    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;

        GameObject o = dict1[name];
        o.transform.position = t.transform.position;
        o.transform.rotation = t.transform.rotation;
        o.SetActive(true);

    }

    void UpdateSound(ARTrackedImage t)
    {
        string name=t.referenceImage.name;

        AudioClip sound = dict2[name];
        GetComponent<AudioSource>().PlayOneShot(sound);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
