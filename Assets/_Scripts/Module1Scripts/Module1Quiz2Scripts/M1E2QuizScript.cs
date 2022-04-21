using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M1E2QuizScript : MonoBehaviour
{
    [SerializeField] TMP_Text FindSigFigTxt;
    [SerializeField] TMP_Text PromptText;

    [SerializeField] TMP_Text AnswerTxt1;
    [SerializeField] TMP_Text AnswerTxt2;
    [SerializeField] TMP_Text AnswerTxt3;
    [SerializeField] TMP_Text AnswerTxt4;
    [SerializeField] TMP_Text AnswerTxt5;
    [SerializeField] TMP_Text AnswerTxt6;
    [SerializeField] TMP_Text AnswerTxt7;
    [SerializeField] TMP_Text AnswerTxt8;
    [SerializeField] TMP_Text AnswerTxt9;
    [SerializeField] TMP_Text AnswerTxt10;
    [SerializeField] TMP_Text AnswerTxt11;
    [SerializeField] TMP_Text AnswerTxt12;

    [SerializeField] TMP_Text questionDescription;
    [SerializeField] TMP_Text answerWrongText;
    [SerializeField] TMP_Dropdown answerDropdown;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject returnWarning;
    //[SerializeField] QuizSimScript simScript;
    [SerializeField] Canvas QuizCanvas;

    string[] questionDescriptions = new string[] {"Round 0054.40533330,  the radial acceleration of a ball being whirled around in a 0.3m circle, to 2 significant figures",
    "Round 0009.95193449, the velocity of a car rolling off a 30m cliff at a 37.08 degree angle below the horizontal, to 7 significant figures",
    "Round 0022.91325700, the minumum constant velocity a Road Runner must move to beat a Coyote on rocket roller skates, to 9 significant figures",
    "Round 0266.55449000, the distance a ship can be from a shore to be safe from bombardment of a ship 2500m from the 1800m peak between them, to 6 significant figures"};
    string[] question1CorrectAnswers = {};
    string[] question1WrongAnswer1 = {};
    string[] question1WrongAnswer2 = {};
    string[] question1WrongAnswer3 = {};


    int[] sigFigQuestions = new int[] {2, 7, 9, 6};
    string[] prompts = new string[] {"Radial acceleration of a ball being whirled around in a 0.3m circle", "Velocity of a car rolling off a 30m cliff at a 37.08 degree angle below the horizontal", 
        "Minumum constant velocity a Road Runner must move to beat a Coyote on rocket roller skates", "Distance a ship can be from a shore to be safe from bombardment of a ship 2500m from the 1800m peak between them"};
    string[] promptAnswers = new string[] {"0054.40533330", "0009.95193449", "0022.91325700", "0266.55449000" };
    //string[] promptAnswerUnits = new string[] {"m/s/s", "m/s", "m/s", "m"};
    int arrayIndex = 1;
    //int prevIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        arrayIndex = Random.Range(0, 4);
        GeneratePrompt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratePrompt()
    {
        //prevIndex = arrayIndex;
        //Debug.Log(arrayIndex);
        questionDescription.text = questionDescriptions[arrayIndex];
        //set text boxes to display proper information
        if (arrayIndex == 0)
            FindSigFigTxt.text = "Find the " + sigFigQuestions[arrayIndex] + "nd Significant Figure in the prompt below";
        else
            FindSigFigTxt.text = "Find the " + sigFigQuestions[arrayIndex] + "th Significant Figure in the prompt below";
        PromptText.text = prompts[arrayIndex];
        AnswerTxt1.text = promptAnswers[arrayIndex][0] + "";
        AnswerTxt2.text = promptAnswers[arrayIndex][1] + "";
        AnswerTxt3.text = promptAnswers[arrayIndex][2] + "";
        AnswerTxt4.text = promptAnswers[arrayIndex][3] + "";
        //Skip 4 as that is the decimal
        AnswerTxt5.text = promptAnswers[arrayIndex][5] + "";
        AnswerTxt6.text = promptAnswers[arrayIndex][6] + "";
        AnswerTxt7.text = promptAnswers[arrayIndex][7] + "";
        AnswerTxt8.text = promptAnswers[arrayIndex][8] + "";
        AnswerTxt9.text = promptAnswers[arrayIndex][9] + "";
        AnswerTxt10.text = promptAnswers[arrayIndex][10] + "";
        AnswerTxt11.text = promptAnswers[arrayIndex][11] + "";
        AnswerTxt12.text = promptAnswers[arrayIndex][12] + "";

    }
    //public List<string> GenerateAnswerOrder()
    //{
    //    List<string> answers;
    //    int random = Random.Range(0, 3);
    //    switch (random)
    //    {
    //        case 0:
    //            answers = new List<string> { question1CorrectAnswers[arrayIndex], question1WrongAnswer1[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer3[arrayIndex] };
    //            break;
    //        case 1:
    //            answers = new List<string> { question1WrongAnswer2[arrayIndex], question1CorrectAnswers[arrayIndex], question1WrongAnswer3[arrayIndex], question1WrongAnswer1[arrayIndex] };
    //            break;
    //        case 2:
    //            answers = new List<string> { question1WrongAnswer2[arrayIndex], question1WrongAnswer1[arrayIndex], question1CorrectAnswers[arrayIndex], question1WrongAnswer3[arrayIndex] };
    //            break;
    //        case 3:
    //            answers = new List<string> { question1WrongAnswer3[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer1[arrayIndex], question1CorrectAnswers[arrayIndex] };
    //            break;
    //        default:
    //            answers = new List<string> { question1CorrectAnswers[arrayIndex], question1WrongAnswer1[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer3[arrayIndex] };
    //            break;
    //    }
    //    return answers;
    //}
    public void HideWrongAnswerText()
    {
        answerWrongText.enabled = false;
    }
    //public void CheckAnswer()
    //{
    //    if (answerDropdown.options[answerDropdown.value].text == question1CorrectAnswers[arrayIndex])
    //    {
    //        simScript.SetSimCanvasEnabled(false);
    //        winScreen.SetActive(true);
    //    }
    //    else
    //    {
    //        answerWrongText.enabled = true;
    //    }
    //}
}
