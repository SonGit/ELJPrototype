using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ A");
        }
        else
        {
            // We do not have permission to use the microphone.
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.Microphone);
            Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ B");
        }
    }
	
    void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        GameObject.Find("Text").GetComponent<Text>().text = result[0];

    }

	// Update is called once per frame
	void Update () {
		
	}
}
