using com.ootii.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class CoffeShopMenu : BasicMenu
{
    public static CoffeShopMenu instance;

    [SerializeField] private SettingsMenu settingsMenu;

    [SerializeField] private GameObject recordBnt;
    [SerializeField] private GameObject unrecordBnt;
    


    [Header("Result")]
    [SerializeField] private GameObject resultObj;
    [SerializeField] private Text resultText;

    [Header("Question")]
    [SerializeField] private Text waitressSpeakText_JP;
    [SerializeField] private Text waitressSpeakText_Romaji;

    [Header("Answers")]
    [SerializeField] private GameObject answerObj;
    [SerializeField] private Text answerText_JP;
    [SerializeField] private Text answerText_Romaji;

    [Header("CheckBox")]
    [SerializeField] private GameObject trueCheckBox;
    [SerializeField] private GameObject falseCheckBox;

    [Header("Question_Bnt")]
    [SerializeField] private GameObject restartCurrentQuestionBn;
    [SerializeField] private GameObject nextQuestionObj;

    private int _currentQuestion;



    public Text result
    {
        get
        {
            return resultText;
        }

        set
        {
            resultText = value;
        }
    }

    public int currentQuestion
    {
        get
        {
            return _currentQuestion;
        }

        set
        {
            _currentQuestion = value;
        }
    }

   

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        OnDisableSettingMenu();

        RecordBnt_Onclick();

        OnDisableCheckBox();

        _currentQuestion = 1;

        SetupInfo(_currentQuestion);

    }

    public void SetupInfo(int currentQuestion) {

        //switch (currentQuestion)
        //{
        //    case 1: 
        //        Debug.Log("Question 1............................................");
                
                

        //        break;

        //    case 2:
        //        Debug.Log("Question 2............................................");
                

        //        break;

        //    case 3:
        //        Debug.Log("Question 2............................................");
                

        //        break;

        //    default:

        //        break;
        //}

        _currentQuestion = currentQuestion;


        SetupQuestion(currentQuestion);

        SetupAnswers(currentQuestion);

        RecordBnt_Onclick();
    }

    public void SetupQuestion(int currentQuestion) {
        switch (currentQuestion)
        {
            // Question 1
            case 1:

                if (waitressSpeakText_JP != null && waitressSpeakText_Romaji != null) {
                    waitressSpeakText_JP.text = "こんにちは";
                    waitressSpeakText_Romaji.text = "Kon'nichiwa";

                }

                break;

            // Question 2
            case 2:

                if (waitressSpeakText_JP != null)
                {
                    waitressSpeakText_JP.text = "お飲み物は何にしますか";
                }

                if (waitressSpeakText_Romaji != null)
                {
                    waitressSpeakText_Romaji.text = "O nomimono wa nani ni shimasu ka";
                }



                break;

            // Question 3 
            case 3:

                if (waitressSpeakText_JP != null)
                {
                    waitressSpeakText_JP.text = "ほかにございますか";
                }

                if (waitressSpeakText_Romaji != null)
                {
                    waitressSpeakText_Romaji.text = "Hoka ni gozaimasu ka";
                }

                break;

            // Question 4 
            case 4:

                if (waitressSpeakText_JP != null)
                {
                    waitressSpeakText_JP.text = "どうもありがとうございました。10分おまちください"; 
                }

                if (waitressSpeakText_Romaji != null)
                {
                    waitressSpeakText_Romaji.text = "Dōmo arigatōgozaimashita. Juppun Omachi kudasai.";
                }

                break;

            default:
              

                break;
        }
    }

    public void SetupAnswers(int currentQuestion)
    {
        OnEnableAnswersUI();
        OnDisableResultUI();
        OnDisableNextQuestionBnt();

        switch (currentQuestion)
        {
            // Answers 1
            case 1:

                if (answerText_JP != null && answerText_Romaji != null)
                {
                    answerText_JP.text = "こんにちは"; 
                    answerText_Romaji.text = "Kon'nichiwa";
                }

                break;

            // Answers 2
            case 2:

                if (answerText_JP != null && answerText_Romaji != null)
                {
                    answerText_JP.text = "すみません、コーヒーにします";
                    answerText_Romaji.text = "Sumimasen, Kōhī ni shimasu";
                }


                break;

            case 3:

                if (answerText_JP != null && answerText_Romaji != null)
                {
                    answerText_JP.text = "ハンバーガー 1つ お願いします";
                    answerText_Romaji.text = "Hanbāgā hitotsu onegaishimasu"; 
                }

                break;

            

            case 4:

                if (answerText_JP != null && answerText_Romaji != null)
                {
                    answerText_JP.text = "はい, ありがとうございます"; 
                    answerText_Romaji.text = "Hai, Arigatōgozaimasu";
                }

                break;

            default:


                break;
        }
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

    

    public void SetTrueCheckBoxActive()
    {
        OnSetActive(trueCheckBox, true);
        OnSetActive(falseCheckBox, false);
    }

    public void SetFalseCheckBoxActive()
    {
        OnSetActive(falseCheckBox, true);
        OnSetActive(trueCheckBox, false);
    }

    public void OnDisableCheckBox()
    {
        OnSetActive(falseCheckBox, false);
        OnSetActive(trueCheckBox, false);
    }

    public void GoToCompleteMenu() {
        OnSetActive(settingsMenu.root, true);
    }

    IEnumerator LoadAsyncScene(string name)
    {
        OnSetActive(this.root, false);
        OnSetActive(settingsMenu.root, false);

        yield return new WaitForSeconds(1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadAsyncSceneMain()
    {
        StartCoroutine(LoadAsyncScene("Main"));
    }

    public void UnrecordBnt_Onclick() {

        if (resultText != null)
        {
            resultText.text = "....................";
        }
        else
        {
            Debug.LogError("NULL................");
        }

        OnSetActive(recordBnt, true);
        OnSetActive(unrecordBnt, false);


#if UNITY_ANDROID && !UNITY_EDITOR
            TaskOnClick();
#endif

    }

    public void RecordBnt_Onclick()
    {
        if (resultText != null)
        {
            resultText.text = "Click To Start Speak";
        }
        else
        {
            Debug.LogError("NULL................");
        }

        OnSetActive(recordBnt, false);
        OnSetActive(unrecordBnt, true);

    }


    public void OnEnableAnswersUI()
    {
        OnSetActive(answerObj, true);
    }

    public void OnDisableAnswersUI()
    {
        OnSetActive(answerObj, false);
    }

    public void OnEnableResultUI()
    {
        OnSetActive(resultObj, true);
    }

    public void OnDisableResultUI()
    {
        OnSetActive(resultObj, false);
    }

    public void OnDisableSettingMenu()
    {
        if (settingsMenu != null)
        {
            settingsMenu.OnDisableSettingMenu();
        }
    }

    public void OnEnableSettingMenu()
    {
        if (settingsMenu != null)
        {
            settingsMenu.OnEnableSettingMenu();
        }
    }

    public void RestartAll() {
        Init();
    }

    public void OnDisableNextQuestionBnt()
    {
        OnSetActive(nextQuestionObj, false);
    }

    public void OnEnableNextQuestionBnt()
    {
        OnSetActive(nextQuestionObj, true);
    }

    public void NextQuestionBnt_OnClick()
    {
        int nextQuestion = _currentQuestion + 1;
        SetupInfo(nextQuestion);
    }

    public void RestartCurrentQuestionBnt_OnClick()
    {
        SetupInfo(_currentQuestion);
    }
}
