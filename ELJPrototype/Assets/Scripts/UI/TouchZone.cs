using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZone : MonoBehaviour
{
    [SerializeField] private GameObject playBnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        if (playBnt != null)
        {
            playBnt.SetActive(true);
        }
    }

    public void OnPointerExit()
    {
        if (playBnt != null)
        {
            playBnt.SetActive(false);
        }
    }
}
