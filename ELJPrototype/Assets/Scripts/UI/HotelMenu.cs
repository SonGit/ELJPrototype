using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelMenu : BasicMenu
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }


    protected override void SetupInfos(int currentQuestion)
    {
        base.SetupInfos(currentQuestion);
    }

    protected override void SetupQuestions(int currentQuestion)
    {
        switch (currentQuestion)
        {
            // Question 1
            case 1:

                SetupQuestion("いらっしゃいませ", "Irasshaimase");

                break;

            // Question 2
            case 2:

                SetupQuestion("部屋をご予約になりますか", "Heya o goyoyaku ni narimasu ka");

                break;

            // Question 3 
            case 3:

                SetupQuestion("どんな部屋を借りたいですか", "Don'na heya o karitai desu ka");

                break;

            // Question 4 
            case 4:

                SetupQuestion("客室料金は50円です", "Kyakushitsu ryōkin wa 50-En desu");

                break;

            default:

                RestartAll();
                break;
        }
    }


    protected override void SetupAnswers(int currentQuestion)
    {
        base.SetupAnswers(currentQuestion);


        switch (currentQuestion)
        {
            // Answers 1
            case 1:

                SetupAnswer("こんにちは", "Kon'nichiwa");

                break;

            // Answers 2
            case 2:

                SetupAnswer("一室を借りたいです", "Isshitsu o karitai desu");

                break;

            // Answers 3
            case 3:

                SetupAnswer("大きい部屋を借りたいです", "Ōkī heya o karitai desu");

                break;


            // Answers 4
            case 4:

                SetupAnswer("はい, ありがとうございます", "Hai, Arigatōgozaimasu");

                break;

            default:

                break;
        }
    }
}
