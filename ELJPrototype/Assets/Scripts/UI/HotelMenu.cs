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

                SetupQuestion("こんにちは", "Kon'nichiwa");

                break;

            // Question 2
            case 2:

                SetupQuestion("お飲み物は何にしますか", "O nomimono wa nani ni shimasu ka");

                break;

            // Question 3 
            case 3:

                SetupQuestion("ほかにございますか", "Hoka ni gozaimasu ka");

                break;

            // Question 4 
            case 4:

                SetupQuestion("どうもありがとうございました。10分おまちください", "Dōmo arigatōgozaimashita. Juppun Omachi kudasai.");

                break;

            default:

                SetupQuestion("こんにちは", "Kon'nichiwa");
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

                SetupAnswer("すみません、コーヒーにします", "Sumimasen, Kōhī ni shimasu");

                break;

            // Answers 3
            case 3:

                SetupAnswer("ハンバーガー 1つ お願いします", "Hanbāgā hitotsu onegaishimasu");

                break;


            // Answers 4
            case 4:

                SetupAnswer("はい, ありがとうございます", "Hai, Arigatōgozaimasu");

                break;

            default:

                SetupAnswer("こんにちは", "Kon'nichiwa");
                break;
        }
    }
}
