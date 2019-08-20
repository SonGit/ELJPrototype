using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using System.Linq;

public class ReceiveResult : MonoBehaviour
{
    string[] coffeShop_Answers1 = { "こんにちは", "今日は" };
    string[] coffeShop_Answers2 = { "すみませんコーヒーにします" };
    string[] coffeShop_Answers3 = { "ハンバーガー一つお願いします" };
    string[] coffeShop_Answers4 = { "はいありがとうございます" };


    string[] bank_Answers1 = { "こんにちは", "今日は" };
    string[] bank_Answers2 = { "すみません預金口座を作りたいのですが" };
    string[] bank_Answers3 = { "はいそうです" }; 
    string[] bank_Answers4 = { "はいわかりました" };
    string[] bank_Answers5 = { "はいありがとうございます" };

    private bool stringExists;

    [SerializeField] private BasicMenu basicMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (basicMenu == null)
        {
            if (CoffeShopMenu.Instance != null)
            {
                basicMenu = CoffeShopMenu.Instance;
            }

            if (BankMenu.Instance != null)
            {
                basicMenu = BankMenu.Instance;
            }

        }
    }

    void onActivityResult(string recognizedText)
    {

        Debug.Log("++++++++++++++++++++onActivityResult" + recognizedText);

        if (basicMenu != null)
        {
            basicMenu.OnDisableNextQuestionBnt();
            basicMenu.RecordBnt_Onclick();

            basicMenu.OnEnableResultUI();

            basicMenu.result.text = recognizedText;

            basicMenu.SetFalseCheckBoxActive();

            // Go to Question 2
            if (basicMenu.currentQuestion == 1)
            {
                if (basicMenu is CoffeShopMenu) {
                    stringExists = coffeShop_Answers1.Contains(recognizedText);
                }

                if (basicMenu is BankMenu)
                {
                    stringExists = bank_Answers1.Contains(recognizedText);
                }

                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "1");

                    RightAnswer();

                    basicMenu.OnEnableNextQuestionBnt();

                }
                else
                {
                    WrongAnswer();
                }

            }

            // Go to Question 3
            if (basicMenu.currentQuestion == 2)
            {
                if (basicMenu is CoffeShopMenu)
                {
                    stringExists = coffeShop_Answers2.Contains(recognizedText);
                }

                if (basicMenu is BankMenu)
                {
                    stringExists = bank_Answers2.Contains(recognizedText);
                }

                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "2");

                    RightAnswer();

                    basicMenu.OnEnableNextQuestionBnt();

                }
                else
                {
                    WrongAnswer();
                }
            }

            // Go to Question 4
            if (basicMenu.currentQuestion == 3)
            {
                if (basicMenu is CoffeShopMenu)
                {
                    stringExists = coffeShop_Answers3.Contains(recognizedText);
                }

                if (basicMenu is BankMenu)
                {
                    stringExists = bank_Answers3.Contains(recognizedText);
                }


                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "3");

                    RightAnswer();

                    basicMenu.OnEnableNextQuestionBnt();

                }
                else
                {
                    WrongAnswer();
                }
            }

            // Go to Question 5
            if (basicMenu.currentQuestion == 4)
            {
                if (basicMenu is CoffeShopMenu)
                {
                    stringExists = coffeShop_Answers4.Contains(recognizedText);
                }

                if (basicMenu is BankMenu)
                {
                    stringExists = bank_Answers4.Contains(recognizedText);
                }

                if (stringExists)
                {
                    RightAnswer();

                    if (basicMenu is CoffeShopMenu)
                    {
                        Debug.Log("Setup++++++++++++++++++++++++++++++ : " + "Completed");

                        basicMenu.GoToCompleteMenu();

                    }

                    if (basicMenu is BankMenu)
                    {
                        basicMenu.OnEnableNextQuestionBnt();
                    }

                }
                else
                {
                    WrongAnswer();
                }

            }

            // Go to Question 6
            if (basicMenu.currentQuestion == 5)
            {
                if (basicMenu is BankMenu)
                {
                    stringExists = bank_Answers5.Contains(recognizedText);
                }

                if (stringExists)
                {
                    RightAnswer();

                    if (basicMenu is BankMenu)
                    {
                        Debug.Log("Setup++++++++++++++++++++++++++++++ : " + "Completed");

                        basicMenu.GoToCompleteMenu();
                    }

                }
                else
                {
                    WrongAnswer();
                }

            }
        }
    }

    void onError(string errorCode)
    {

        Debug.Log("++++++++++++++++++++Errror" + errorCode);

        if (basicMenu != null)
        {
            basicMenu.RecordBnt_Onclick();
        }

    }


    public void RightAnswer() {

        basicMenu.SetTrueCheckBoxActive();

        basicMenu.female_Animator.SetTrigger("AgreeTrigger");
    }

    public void WrongAnswer()
    {
        basicMenu.female_Animator.SetTrigger("DenyTrigger");
    }

   
}
