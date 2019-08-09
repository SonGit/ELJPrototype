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
    


    [Header("Result")]
    [SerializeField] private Text resultText;

    [Header("Question")]
    [SerializeField] private Text questionText_JP;
    [SerializeField] private Text questionText_US;

    [Header("SaySomeThing_01")]
    [SerializeField] private Text answerText_01_JP;
    [SerializeField] private Text answerText_01_US;

    [Header("SaySomeThing_02")]
    [SerializeField] private Text answerText_02_JP;
    [SerializeField] private Text answerText_02_US;

    [Header("SaySomeThing_03")]
    [SerializeField] private Text answerText_03_JP;
    [SerializeField] private Text answerText_03_US;

    [Header("CheckBox")]
    [SerializeField] private GameObject trueCheckBox;
    [SerializeField] private GameObject falseCheckBox;

    [SerializeField] private int currentQuestion;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        SetupInfo(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupInfo(int currentQuestion) {
        switch (currentQuestion)
        {
            case 1: 
                Debug.Log("Question 1............................................");
                this.currentQuestion = currentQuestion;

                break;

            case 2:
                Debug.Log("Question 2............................................");
                this.currentQuestion = currentQuestion;

                break;
          
            default:

                break;
        }

        SetupQuestion(currentQuestion);

        SetupAnswers(currentQuestion);
    }

    public void SetupQuestion(int currentQuestion) {
        switch (currentQuestion)
        {
            case 1:

                if (questionText_JP != null) {
                    questionText_JP.text = "こんにちは";
                }

                if (questionText_US != null)
                {
                    questionText_US.text = "Hello";
                }

                break;

            case 2:

                if (questionText_JP != null)
                {
                    questionText_JP.text = "あなたの名前は何ですか";
                }

                if (questionText_US != null)
                {
                    questionText_US.text = "What is your name";
                }

                break;

            default:
               

                break;
        }
    }

    public void SetupAnswers(int currentQuestion)
    {
        switch (currentQuestion)
        {
            case 1:

                if (answerText_01_JP != null && answerText_01_US != null)
                {
                    answerText_01_JP.text = "こんにちは";
                    answerText_01_US.text = "Hello";
                }

                if (answerText_02_JP != null && answerText_02_US != null)
                {
                    answerText_02_JP.text = "こんにちは";
                    answerText_02_US.text = "Hello";
                }

                if (answerText_03_JP != null && answerText_03_US != null)
                {
                    answerText_03_JP.text = "こんにちは";
                    answerText_03_US.text = "Hello";
                }

                break;

            case 2:

                if (answerText_01_JP != null && answerText_01_US != null)
                {
                    answerText_01_JP.text = "私の名前は...";
                    answerText_01_US.text = "My name is...";
                }

                if (answerText_02_JP != null && answerText_02_US != null)
                {
                    answerText_02_JP.text = "私の名前は...";
                    answerText_02_US.text = "My name is...";
                }

                if (answerText_03_JP != null && answerText_03_US != null)
                {
                    answerText_03_JP.text = "私の名前は...";
                    answerText_03_US.text = "My name is...";
                }

                break;

            default:


                break;
        }
    }

    public void OnMicroPhoneBnt_Play()
    {
        // See if the message passes in data
        if (resultText != null)
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
    }

    public void OnMicroPhoneBnt_PauseMessageReceived(IMessage rMessage)
    {
        // See if the message passes in data
        if (resultText != null)
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
