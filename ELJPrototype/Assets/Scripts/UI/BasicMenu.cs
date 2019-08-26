using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class BasicMenu : Singleton<BasicMenu>
{
    [SerializeField] protected GameObject root;

    [SerializeField] protected SettingsMenu settingsMenu;


    [Header("Result")]
    [SerializeField] protected Text resultText;

    [Header("Question")]
    [SerializeField] protected Text waitressSpeakText_JP;
    [SerializeField] protected Text waitressSpeakText_Romaji;

    [Header("Answers")]
    [SerializeField] protected Text answerText_JP;
    [SerializeField] protected Text answerText_Romaji;

    [Header("CheckBox")]
    [SerializeField] protected GameObject trueCheckBox;
    [SerializeField] protected GameObject falseCheckBox;


    [Header("ButtonEffect")]
    [SerializeField] protected ButtonEffect waitressSpeakButtonEffect;
    [SerializeField] protected ButtonEffect resultButtonEffect;
    [SerializeField] protected ButtonEffect nextQuestionButtonEffect;
    [SerializeField] protected GameObject recordBnt;
    [SerializeField] protected ButtonEffect unrecordBntEffect;
    [SerializeField] protected Text noticeText;

    [Header("Animator")]
    [SerializeField] protected Animator femaleAnimator;

    protected int _currentQuestion;
    protected bool isNextQuestionBntEnable;
    protected bool isunrecordBntEffectEnable;


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

    public Animator female_Animator
    {
        get
        {
            return femaleAnimator;
        }

        set
        {
            femaleAnimator = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        Init();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (nextQuestionButtonEffect != null && isNextQuestionBntEnable)
        {
            nextQuestionButtonEffect.Play();
        }

        if (unrecordBntEffect != null && isunrecordBntEffectEnable)
        {
            unrecordBntEffect.Play();
        }
    }

    private void Init()
    {
        Hello();

        OnDisableSettingMenu();

        RecordBnt_Onclick();

        OnDisableCheckBox();

        _currentQuestion = 1;

        SetupInfos(_currentQuestion);

        if (CameraControl.Instance != null)
        {
            CameraControl.Instance.ResetCameraDefault();
        }

    }

    public void UnrecordBnt_Onclick()
    {

        if (noticeText != null)
        {
            noticeText.text = "Speak...........................";
        }
        else
        {
            Debug.LogError("NULL................");
        }

        OnSetActive(recordBnt, true);
        OnSetActive(unrecordBntEffect.gameObject, false);
        isunrecordBntEffectEnable = false;
        OnDisableResultUI();


#if UNITY_ANDROID && !UNITY_EDITOR
        TaskOnClick();
#endif

    }

    public void RecordBnt_Onclick()
    {
        if (noticeText != null)
        {
            noticeText.text = "Click To Start Speak";
        }
        else
        {
            Debug.LogError("NULL................");
        }

        OnSetActive(recordBnt, false);
        OnSetActive(unrecordBntEffect.gameObject, true);
        isunrecordBntEffectEnable = true;

#if UNITY_ANDROID && !UNITY_EDITOR
         StopRecord();
#endif

    }



    protected void OnSetActive(GameObject obj, bool value)
    {
        if (obj != null)
        {
            obj.SetActive(value);
        }
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

    public void GoToCompleteMenu()
    {
        OnSetActive(settingsMenu.root, true);

        if (settingsMenu != null)
        {
            settingsMenu.SetSettingHeader("Congratulations");
        }

    }

    public void OnEnableResultUI()
    {
        OnSetActive(resultButtonEffect.gameObject, true);

        if (resultButtonEffect != null)
        {
            resultButtonEffect.Play();
        }
    }

    public void OnDisableResultUI()
    {
        OnSetActive(resultButtonEffect.gameObject, false);
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

    public void RestartAll()
    {
        Init();
    }

    public void OnDisableNextQuestionBnt()
    {
        OnSetActive(nextQuestionButtonEffect.gameObject, false);

        isNextQuestionBntEnable = false;
    }

    public void OnEnableNextQuestionBnt()
    {
        OnSetActive(nextQuestionButtonEffect.gameObject, true);

        isNextQuestionBntEnable = true;
    }

    public void NextQuestionBnt_OnClick()
    {
        int nextQuestion = _currentQuestion + 1;
        SetupInfos(nextQuestion);
    }

    public void Hello()
    {
        if (femaleAnimator != null) {
            femaleAnimator.SetTrigger("HelloTrigger");
        }
        
    }

    protected virtual void SetupInfos(int currentQuestion)
    {
        _currentQuestion = currentQuestion;

        SetupQuestions(currentQuestion);

        SetupAnswers(currentQuestion);

        RecordBnt_Onclick();

        OnDisableResultUI();

        OnDisableNextQuestionBnt();

        if (waitressSpeakButtonEffect != null)
        {
            waitressSpeakButtonEffect.Play();
        }

        if (FemaleController.Instance != null)
        {
            FemaleController.Instance.PlayFemale_MouthAnimation();
        }
    }

    protected virtual void SetupQuestions(int currentQuestion)
    {

    }

    protected void SetupQuestion(string question_JP, string question_Romaji)
    {
        if (waitressSpeakText_JP != null && waitressSpeakText_Romaji != null)
        {
            waitressSpeakText_JP.text = question_JP;
            waitressSpeakText_Romaji.text = question_Romaji;

        }
    }

    protected virtual void SetupAnswers(int currentQuestion)
    {
       
    }

    protected void SetupAnswer(string answer_JP, string answer_Romaji)
    {
        if (answerText_JP != null && answerText_Romaji != null)
        {
            answerText_JP.text = answer_JP;
            answerText_Romaji.text = answer_Romaji;
        }
    }

    #region Start/Stop Record

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
    void StopRecordUIThread()
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = pluginClass.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("stopSpeechInput");
    }

    void StopRecord()
    {
        AndroidJavaClass pluginClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = pluginClass.GetStatic<AndroidJavaObject>("currentActivity");

        activity.Call("runOnUiThread", new AndroidJavaRunnable(StopRecordUIThread));
    }

    #endregion
}
