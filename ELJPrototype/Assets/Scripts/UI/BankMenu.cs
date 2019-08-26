using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMenu : BasicMenu
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

                SetupQuestion("今日はどんなご用件ですか?", "Kyō wa don'na goyōken desu ka?");
                
                break;

            // Question 3 
            case 3:

                SetupQuestion("新規口座開設(しんきこうざかいせつ) ですね", "Shinki kōza kaisetsu desu ne");

                break;

            // Question 4 
            case 4:

                SetupQuestion("まず、こちらの用紙に記入して頂けますか？", "Mazu, kochira no yōshi ni kinyū shite itadakemasu ka?");

                break;


            // Question 5
            case 5:

                SetupQuestion("手続きいたしますので、少々お待ちください。", "Tetsudzuki itashimasunode, shōshō o machi kudasai.");

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

                SetupAnswer("すみません。預金口座(よきんこうざ)を作りたいのですが", "Sumimasen. Yokin kōza o tsukuritai no desu ga");

                break;

            // Answers 3
            case 3:

                SetupAnswer("はい、そうです", "Hai, Sōdesu");

                break;


            // Answers 4
            case 4:

                SetupAnswer("はい, わかりました", "Hai, Wakarimashita");

                break;

            // Answers 5
            case 5:

                SetupAnswer("はい, ありがとうございます", "Hai, Arigatōgozaimasu");

                break;

            default:

                break;
        }
    }
}
