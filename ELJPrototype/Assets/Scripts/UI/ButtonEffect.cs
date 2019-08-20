using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        System.Collections.Hashtable hash = new System.Collections.Hashtable();
        hash.Add("amount", new Vector3(0.4f, 0.4f, 0f));
        hash.Add("time", 1.5f);
        iTween.PunchScale(gameObject, hash);
    }
}
