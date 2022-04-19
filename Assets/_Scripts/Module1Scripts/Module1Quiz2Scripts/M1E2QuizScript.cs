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
    [SerializeField] QuizSimScript simScript;
    [SerializeField] Canvas QuizCanvas;

    int[] sigFigQuestions = new int[] { 6, 8, 4, 5, 7, 5, 10 };
    string[] prompts = new string[] {"Average velocity of a car having traveled 8.4km in 2.03s", "Force on a 12.34kg block accelerating at 5.242m/s", "Launch speed of a ball thrown at a 54 degree angle traveling 24m in 2.2s",
        "Revolutions per second required to give an astronaut of 29.4m/s in a circular motion w/ 9.45m radius", "Speed of a wrecking ball rotating counterclockwise with (-22/5i + 20.2j)m/s/s acceleration",
        "Maximum speed a light truck can go around a 75m radius curve at 32m/s", "Initial speed a 2m tall basketball player standing 10m from a 3.05m hoop must throw the ball to get nothing but net."};
    string[] promptAnswers = new string[] { "0004.13793103", "0064.68628000", "0018.14602160", "0000.28075268", "0006.67008246", "0022.62741700", "0010.66395800" };
    string[] promptAnswerUnits = new string[] { "km/s", "N", "m/s", "rps", "m/s", "m/s", "m/s" };
    int arrayIndex = 1;
    int prevIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratePrompt()
    {
        while (arrayIndex == prevIndex)
            arrayIndex = Random.Range(0, 6);
        prevIndex = arrayIndex;

        //set text boxes to display proper information
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
