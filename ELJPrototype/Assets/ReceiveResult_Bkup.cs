using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using System.Linq;

public class ReceiveResult_Bkup : MonoBehaviour
{

    string[] answers1Array = { "こんにちは", "今日は", "こんばんは", "今晩は", "こんにちはお元気ですか", "こんにちはおげんきですか", "今日はお元気ですか", "今日はおげんきですか" };

    string[] answers2_01Array = { "ジュース" };

    string[] answers2_02Array = { "コーヒー" };
    string[] answers2_03Array = { "お酒", "酒" };
    string[] answers2_01_01Array = { "オレンジジュース", "グレープジュース", "アップルジュース" };
    string[] answers2_02_01Array = { "ミルクコーヒー", "アイスコーヒー", "ブラックコーヒー" };
    string[] answers2_03_01Array = { "にほんしゅ", "日本酒", "ウィスキー", "ワイン" };

    string[] answers3Array = { "お好み焼き", "ピザ", "かしパン", "菓子パン" };

    string[] answers4Array = { "はい", "ほんとうにありがとうございます", "本当にありがとうございます", "ありがとうございます" };

    // Use this for initialization
    void Start()
    {

    }

    void onActivityResult(string recognizedText)
    {

        Debug.Log("++++++++++++++++++++onActivityResult" + recognizedText);

        if (Panel_01Menu.instance != null)
        {
            Panel_01Menu.instance.result.text = recognizedText;

            Panel_01Menu.instance.SetFalseCheckBoxActive();

            // Go to Question 2
            if (Panel_01Menu.instance.currentQuestion == 1)
            {
                bool stringExists = answers1Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "1");

                    Panel_01Menu.instance.SetupInfo(2, keyString.None);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();

                }
                else
                {
                    Debug.Log("++++++++++++++++++++++++++++++ currentkey:" + Panel_01Menu.instance.currentkey);

                    Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);
                }
            }

            // Question 2 -> Go to Question 2.1, 2.2, 2.3
            if (Panel_01Menu.instance.currentQuestion == 2 && Panel_01Menu.instance.currentkey == keyString.None)
            {
                bool string2_01Exists = answers2_01Array.Contains(recognizedText);
                bool string2_02Exists = answers2_02Array.Contains(recognizedText);
                bool string2_03Exists = answers2_03Array.Contains(recognizedText);

                // case 1 of Question 2
                if (string2_01Exists)
                {
                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "2_01");

                    Panel_01Menu.instance.SetupInfo(2, keyString.Answers2_01);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();

                }

                // case 2 of Question 2
                else if (string2_02Exists)
                {
                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "2_02");

                    Panel_01Menu.instance.SetupInfo(2, keyString.Answers2_02);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();
                }

                // case 3 of Question 2
                else if (string2_03Exists)
                {
                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "2_03");

                    Panel_01Menu.instance.SetupInfo(2, keyString.Answers2_03);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();
                }

                else
                {
                    Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);

                    
                }
            }

            //  Case 2.1, 2.2, 2.3 -> Go to Question 3
            if (Panel_01Menu.instance.currentQuestion == 2 && (Panel_01Menu.instance.currentkey == keyString.Answers2_01 || Panel_01Menu.instance.currentkey == keyString.Answers2_02 || Panel_01Menu.instance.currentkey == keyString.Answers2_03))
            {
                bool string2_01_01Exists = answers2_01_01Array.Contains(recognizedText);
                bool string2_02_01Exists = answers2_02_01Array.Contains(recognizedText);
                bool string2_03_01Exists = answers2_03_01Array.Contains(recognizedText);

                if (string2_01_01Exists || string2_02_01Exists || string2_03_01Exists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "3");

                    Panel_01Menu.instance.SetupInfo(3, keyString.None);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();

                }
                else
                {
                    Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);
                }
            }

            // Go to Question 4
            if (Panel_01Menu.instance.currentQuestion == 3 && Panel_01Menu.instance.currentkey == keyString.None)
            {
                bool stringExists = answers3Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ CurrentQuestion: " + "3");

                    Panel_01Menu.instance.SetupInfo(4, keyString.None);

                    Panel_01Menu.instance.SetTrueCheckBoxActive();

                }
                else
                {
                    Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);

                    
                }
            }

            // End
            if (Panel_01Menu.instance.currentQuestion == 4 && Panel_01Menu.instance.currentkey == keyString.None)
            {
                bool stringExists = answers4Array.Contains(recognizedText);
                if (stringExists)
                {

                    Debug.Log("Setup++++++++++++++++++++++++++++++ End");

                    Panel_01Menu.instance.GoToCompleteMenu();

                    Panel_01Menu.instance.SetTrueCheckBoxActive();

                }
                else
                {
                    Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);

                   
                }
            }
        }
    }

        void onError(string errorCode)
        {

            Debug.Log("++++++++++++++++++++Errror" + errorCode);

            if (Panel_01Menu.instance != null)
            {
                Panel_01Menu.instance.result.text = "Click To Start Recording";

                Panel_01Menu.instance.SetupInfo(Panel_01Menu.instance.currentQuestion, Panel_01Menu.instance.currentkey);

                Panel_01Menu.instance.OnDisableCheckBox();
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
}
