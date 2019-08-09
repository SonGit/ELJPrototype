using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    Button btn;
	// Use this for initialization
	void Start () {
        
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}

    void runOnUiThread()
    {
        Debug.Log("I'm running on the Java UI thread!");
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = pluginClass.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("promptSpeechInput");
    }

    void TaskOnClick()
    {   
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = pluginClass.GetStatic<AndroidJavaObject>("currentActivity");

        activity.Call("runOnUiThread", new AndroidJavaRunnable(runOnUiThread)); 
    }

	// Update is called once per frame
	void Update () {
		
	}
}
