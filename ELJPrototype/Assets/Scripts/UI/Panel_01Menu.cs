using com.ootii.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_01Menu : MonoBehaviour
{
    public static Panel_01Menu instance;

    [SerializeField] private GameObject loadingObj;
    [SerializeField] private GameObject microPhoneBnt_PauseObj;
    [SerializeField] private GameObject microPhoneBnt_PlayObj;
    [SerializeField] private Text resultText;
    

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMicroPhoneBnt_PlayMessageReceived(IMessage rMessage)
    {
        // See if the message passes in data
        if (rMessage.Data != null && resultText != null)
        {
            resultText.text = "Click To Start Recording";
        }
        else {
            Debug.LogError("NULL................");
        }

        if (microPhoneBnt_PauseObj != null && microPhoneBnt_PlayObj != null) {
            microPhoneBnt_PauseObj.SetActive(true);
            microPhoneBnt_PlayObj.SetActive(false);
        }

        if (loadingObj != null)
        {
            loadingObj.SetActive(false);
        }

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }

    public void OnMicroPhoneBnt_PauseMessageReceived(IMessage rMessage)
    {
        // See if the message passes in data
        if (rMessage.Data != null && resultText != null)
        {
            resultText.text = "Say...............";
        }
        else
        {
            Debug.LogError("NULL................");
        }

        if (microPhoneBnt_PauseObj != null && microPhoneBnt_PlayObj != null)
        {
            microPhoneBnt_PauseObj.SetActive(false);
            microPhoneBnt_PlayObj.SetActive(true);
        }

        if (loadingObj != null)
        {
            loadingObj.SetActive(true);
        }

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }
}
