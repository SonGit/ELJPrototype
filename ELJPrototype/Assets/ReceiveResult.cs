using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using System.Linq;

public class ReceiveResult : MonoBehaviour
{
    string[] answers1Array = { "こんにちは", "今日は" };
    string[] answers2Array = { "すみませんコーヒーにします" };
    string[] answers3Array = { "ハンバーガーーつお願いします" };
    string[] answers4Array = { "はいありがとうございます" };


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void onActivityResult(string recognizedText)
    {

        Debug.Log("++++++++++++++++++++onActivityResult" + recognizedText);

        if (CoffeShopMenu.instance != null)
        {
            CoffeShopMenu.instance.OnDisableAnswersUI();
            CoffeShopMenu.instance.OnEnableResultUI();
            CoffeShopMenu.instance.OnDisableNextQuestionBnt();
            CoffeShopMenu.instance.RecordBnt_Onclick();

            CoffeShopMenu.instance.result.text = recognizedText;

            CoffeShopMenu.instance.SetFalseCheckBoxActive();

            // Go to Question 2
            if (CoffeShopMenu.instance.currentQuestion == 1)
            {
                bool stringExists = answers1Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "1");

                    CoffeShopMenu.instance.SetTrueCheckBoxActive();

                    CoffeShopMenu.instance.OnEnableNextQuestionBnt();

                }
            }

            // Go to Question 3
            if (CoffeShopMenu.instance.currentQuestion == 2)
            {
                bool stringExists = answers2Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "2");

                    CoffeShopMenu.instance.SetTrueCheckBoxActive();

                    CoffeShopMenu.instance.OnEnableNextQuestionBnt();

                }
            }

            // Go to Question 4
            if (CoffeShopMenu.instance.currentQuestion == 3)
            {
                bool stringExists = answers3Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "3");

                    CoffeShopMenu.instance.SetTrueCheckBoxActive();

                    CoffeShopMenu.instance.OnEnableNextQuestionBnt();

                }
            }

            // Completed
            if (CoffeShopMenu.instance.currentQuestion == 4)
            {
                bool stringExists = answers4Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "Completed");

                    CoffeShopMenu.instance.SetTrueCheckBoxActive();

                    CoffeShopMenu.instance.GoToCompleteMenu();

                }
            }
        }
    }

    void onError(string errorCode)
    {

        Debug.Log("++++++++++++++++++++Errror" + errorCode);

        if (CoffeShopMenu.instance != null)
        {
            //CoffeShopMenu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);

            CoffeShopMenu.instance.RecordBnt_Onclick();

            CoffeShopMenu.instance.OnDisableNextQuestionBnt();
        }

    }

    
}
