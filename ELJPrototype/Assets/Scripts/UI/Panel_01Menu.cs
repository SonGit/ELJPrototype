using com.ootii.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum keyString
{
    None,
    Answers2_01,
    Answers2_02,
    Answers2_03,
}


public class Panel_01Menu : BasicMenu
{
    public static Panel_01Menu instance;

    [SerializeField] private SettingsMenu settingsMenu;

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

    private int _currentQuestion;
    private keyString _currentkey;



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

    public keyString currentkey
    {
        get
        {
            return _currentkey;
        }

        set
        {
            _currentkey = value;
        }
    }

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        OnSetActive(settingsMenu.root, false);

        OnSetActive(microPhoneBnt_PauseObj, true);
        OnSetActive(microPhoneBnt_PlayObj, false);

        OnSetActive(this.root, true);

        OnDisableCheckBox();

        _currentQuestion = 1;
        SetupInfo(_currentQuestion, keyString.None);

    }

    public void SetupInfo(int currentQuestion, keyString key) {

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

        _currentkey = key;

        SetupQuestion(currentQuestion, key);

        SetupAnswers(currentQuestion, key);

        OnMicroPhoneBnt_Play();
    }

    public void SetupQuestion(int currentQuestion, keyString key) {
        switch (currentQuestion)
        {
            // Question 1
            case 1:

                if (questionText_JP != null) {
                    questionText_JP.text = "Kon'nichiwa";
                }

                if (questionText_US != null)
                {
                    questionText_US.text = "Hello";
                }

                break;

            // Question 2
            case 2:

                if (key == keyString.None) {
                    if (questionText_JP != null)
                    {
                        questionText_JP.text = "Kochira ga menyūdegozaimasu. Nani ni shimasu ka";
                    }

                    if (questionText_US != null)
                    {
                        questionText_US.text = "Here is the menu. What would you like?";
                    }
                }

                // case 1 of Question2
                if (key == keyString.Answers2_01)
                {
                    if (questionText_JP != null)
                    {
                        questionText_JP.text = "Jūsu wa nani ni shimasu ka";
                    }

                    if (questionText_US != null)
                    {
                        questionText_US.text = "What kind of Juice do you like?";
                    }
                }

                // case 2 of Question2
                if (key == keyString.Answers2_02)
                {
                    if (questionText_JP != null)
                    {
                        questionText_JP.text = "Kōhī wa nani ni shimasu ka";
                    }

                    if (questionText_US != null)
                    {
                        questionText_US.text = "What kind of Coffe do you like?";
                    }
                }

                // case 3 of Question2
                if (key == keyString.Answers2_03)
                {
                    if (questionText_JP != null)
                    {
                        questionText_JP.text = "Osake wa nani ni shimasu ka";
                    }

                    if (questionText_US != null)
                    {
                        questionText_US.text = "What kind of Wine do you like?";
                    }
                }

                break;

            // Question 3 
            case 3:

                if (questionText_JP != null)
                {
                    questionText_JP.text = "Hoka ni gozaimasu ka";
                }

                if (questionText_US != null)
                {
                    questionText_US.text = "Is there anything else?";
                }

                break;

            // Question 4 
            case 4:

                if (questionText_JP != null)
                {
                    questionText_JP.text = "Arigatōgozaimasu. juppun Omachi kudasai.";
                }

                if (questionText_US != null)
                {
                    questionText_US.text = "Thank you. Please wait 10 minutes";
                }

                break;

            default:
              

                break;
        }
    }

    public void SetupAnswers(int currentQuestion, keyString key)
    {
        switch (currentQuestion)
        {
            // Answers 1
            case 1:

                if (answerText_01_JP != null && answerText_01_US != null)
                {
                    answerText_01_JP.text = "Kon'nichiwa";
                    answerText_01_US.text = "Hello";
                }

                if (answerText_02_JP != null && answerText_02_US != null)
                {
                    answerText_02_JP.text = "Konbanwa";
                    answerText_02_US.text = "Good evening";
                }

                if (answerText_03_JP != null && answerText_03_US != null)
                {
                    answerText_03_JP.text = "Kon'nichiwa, ogenkidesuka";
                    answerText_03_US.text = "Hello, how are you?";
                }

                break;

            // Answers 2
            case 2:

                if (key == keyString.None)
                {
                    if (answerText_01_JP != null && answerText_01_US != null)
                    {
                        answerText_01_JP.text = "Jūsu";
                        answerText_01_US.text = "Juice";
                    }

                    if (answerText_02_JP != null && answerText_02_US != null)
                    {
                        answerText_02_JP.text = "Kōhī";
                        answerText_02_US.text = "Coffe";
                    }

                    if (answerText_03_JP != null && answerText_03_US != null)
                    {
                        answerText_03_JP.text = "おさけ";
                        answerText_03_US.text = "Wine";
                    }
                }

                if (key == keyString.Answers2_01)
                {
                    if (answerText_01_JP != null && answerText_01_US != null)
                    {
                        answerText_01_JP.text = "Orenji jūsu";
                        answerText_01_US.text = "Orange juice";
                    }

                    if (answerText_02_JP != null && answerText_02_US != null)
                    {
                        answerText_02_JP.text = "Gurēpu jūsu";  //グレープジュース
                        answerText_02_US.text = "Grape juice";
                    }

                    if (answerText_03_JP != null && answerText_03_US != null)
                    {
                        answerText_03_JP.text = "Appuru jūsu";  //アップルジュース
                        answerText_03_US.text = "Apple juice";
                    }
                }

                if (key == keyString.Answers2_02)
                {
                    if (answerText_01_JP != null && answerText_01_US != null)
                    {
                        answerText_01_JP.text = "Miruku kōhī"; //ミルク　コーヒー
                        answerText_01_US.text = "Milk coffee";
                    }

                    if (answerText_02_JP != null && answerText_02_US != null)
                    {
                        answerText_02_JP.text = "Aisu kōhī"; // アイス コーヒー
                        answerText_02_US.text = "Ice coffee";
                    }

                    if (answerText_03_JP != null && answerText_03_US != null)
                    {
                        answerText_03_JP.text = "Burakku kōhī";
                        answerText_03_US.text = "Black coffee";
                    }
                }

                if (key == keyString.Answers2_03)
                {
                    if (answerText_01_JP != null && answerText_01_US != null)
                    {
                        answerText_01_JP.text = "Nihon shu";
                        answerText_01_US.text = "Japanese wine";
                    }

                    if (answerText_02_JP != null && answerText_02_US != null)
                    {
                        answerText_02_JP.text = "Uisukī";
                        answerText_02_US.text = "Wishky";
                    }

                    if (answerText_03_JP != null && answerText_03_US != null)
                    {
                        answerText_03_JP.text = "Wain";
                        answerText_03_US.text = "Wine";
                    }
                }


                break;

            case 3:

                if (answerText_01_JP != null && answerText_01_US != null)
                {
                    answerText_01_JP.text = "Okonomiyaki";
                    answerText_01_US.text = "Cake"; 
                }

                if (answerText_02_JP != null && answerText_02_US != null)
                {
                    answerText_02_JP.text = "Piza";
                    answerText_02_US.text = "Pizza";
                }

                if (answerText_03_JP != null && answerText_03_US != null)
                {
                    answerText_03_JP.text = "Kashi pan";
                    answerText_03_US.text = "Sweet bread";
                }

                break;

            

            case 4:

                if (answerText_01_JP != null && answerText_01_US != null)
                {
                    answerText_01_JP.text = "Hai";
                    answerText_01_US.text = "yes";
                }

                if (answerText_02_JP != null && answerText_02_US != null)
                {
                    answerText_02_JP.text = "Hontō ni. Arigatōgozaimasu";
                    answerText_02_US.text = "Really. Thank you";
                }

                if (answerText_03_JP != null && answerText_03_US != null)
                {
                    answerText_03_JP.text = "Arigatōgozaimasu";
                    answerText_03_US.text = "Thank you";
                }

                break;

            default:


                break;
        }
    }

    public void OnMicroPhoneBnt_Play()
    {
        // See if the message passes in data
        //if (resultText != null)
        //{
        //    resultText.text = "Click To Start Recording";
        //}
        //else {
        //    Debug.LogError("NULL................");
        //}

        OnSetActive(microPhoneBnt_PauseObj, true);
        OnSetActive(microPhoneBnt_PlayObj, false);
        OnSetActive(loadingObj, false);
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

        OnSetActive(microPhoneBnt_PauseObj, false);
        OnSetActive(microPhoneBnt_PlayObj, true);
        OnSetActive(loadingObj, true);


#if UNITY_ANDROID && !UNITY_EDITOR
            TaskOnClick();
#endif

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }

    public void OnGoToSettingMessageReceived(IMessage rMessage)
    {
        OnSetActive(settingsMenu.root,true);

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }

    public void OnExitSettingMessageReceived(IMessage rMessage)
    {
        OnSetActive(settingsMenu.root, false);

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }

    public void OnReStartMessageReceived(IMessage rMessage)
    {
        Init();

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
    }

    public void OnHomeMessageReceived(IMessage rMessage)
    {
        LoadAsyncSceneMain();

        // While not required, this is a good way to be tidy
        // and let others know that the message has been handled
        rMessage.IsHandled = true;
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
        OnSetActive(this.root, true);
        OnSetActive(settingsMenu.root, true);
        OnSetActive(loadingObj, false);
    }

    IEnumerator LoadAsyncScene(string name)
    {
        OnSetActive(this.root, false);
        OnSetActive(settingsMenu.root, false);
        OnSetActive(loadingObj, true);

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
}
