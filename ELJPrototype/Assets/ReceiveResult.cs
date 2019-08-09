using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
    void onActivityResult(string recognizedText){

        Debug.Log("++++++++++++++++++++onActivityResult" + recognizedText);
    }

    void onError(string errorCode)
    {

        Debug.Log("++++++++++++++++++++Errror" + errorCode);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
