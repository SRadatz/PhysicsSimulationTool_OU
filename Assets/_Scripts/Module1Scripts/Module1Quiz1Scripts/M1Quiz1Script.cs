using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M1Quiz1Script : MonoBehaviour
{
    [SerializeField] TMP_Text scaleReading;
    [SerializeField] TMP_Text questionDescription;
    [SerializeField] TMP_Text answerWrongText;
    [SerializeField] TMP_Dropdown answerDropdown;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject returnWarning;
    [SerializeField] QuizSimScript simScript;
    [SerializeField] Canvas QuizCanvas;
    //[SerializeField] GameObject ReturnWarning;

    string question1 = "What combination of units adds up to ";
    string[] question1Prompts = new string[] { "2.143243Mg", "653.0004kg", "322.19242g", "23.1002g", "917.3131g" };
    string[] question1CorrectAnswers = { "2,143kg + 243g", "653,000g + 400mg", "322,192mg + 420ug", "23,100mg + 200ug", "917,313ug + 100ug" };
    string[] question1WrongAnswer1 = { "21,432kg + 43g", "65,300g + 40mg", "3,221,924mg + 20ug", "231,000mg + 2000ug", "91,731ug + 3100ug" };
    string[] question1WrongAnswer2 = { "214,324kg + 3g", "6,530g + 400mg", "32,219mg + 2420ug", "2,310mg + 2000ug", "9,173,100ug + 31ug" };
    string[] question1WrongAnswer3 = { "0.2143243kg", "653,400g", "322,192mg + 4,200ug", "231,020mg + 2ug", "9,173ug + 1310ug" };
    
    int arrayIndex;
    //int prevIndex = -1;
    void Start()
    {
        answerWrongText.enabled = false;
        arrayIndex = Random.Range(0, 5);
        //Debug.Log(arrayIndex);
        scaleReading.text = question1Prompts[arrayIndex];
        string[] questionUnits = GetQuestionUnits();
        float xPos = 350f;
        for(int i = 0; i < questionUnits.Length; i++)
        {
            simScript.AddWeight(questionUnits[i], xPos);
            xPos = xPos + 250f;
        }
        questionDescription.text = question1 + question1Prompts[arrayIndex] + "?";
        List<string> questionAnswers = GenerateAnswerOrder();
        answerDropdown.ClearOptions();
        answerDropdown.AddOptions(questionAnswers);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setArrayIndex()
    {
        arrayIndex = Random.Range(0, 4);
        Debug.Log(arrayIndex);
    }
    public List<string> GenerateAnswerOrder()
    {
        List<string> answers;
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                answers = new List<string> { question1CorrectAnswers[arrayIndex], question1WrongAnswer1[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer3[arrayIndex]};
                break;
            case 1:
                answers = new List<string> { question1WrongAnswer2[arrayIndex], question1CorrectAnswers[arrayIndex], question1WrongAnswer3[arrayIndex], question1WrongAnswer1[arrayIndex] };
                break;
            case 2:
                answers = new List<string> { question1WrongAnswer2[arrayIndex], question1WrongAnswer1[arrayIndex], question1CorrectAnswers[arrayIndex], question1WrongAnswer3[arrayIndex] };
                break;
            case 3:
                answers = new List<string> { question1WrongAnswer3[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer1[arrayIndex], question1CorrectAnswers[arrayIndex]};
                break;
            default:
                answers = new List<string> { question1CorrectAnswers[arrayIndex], question1WrongAnswer1[arrayIndex], question1WrongAnswer2[arrayIndex], question1WrongAnswer3[arrayIndex] };
                break;
        }
        return answers;
    }
    public void HideWrongAnswerText()
    {
        answerWrongText.enabled = false;
    }
    public void CheckAnswer()
    {
        if(answerDropdown.options[answerDropdown.value].text == question1CorrectAnswers[arrayIndex])
        {
            simScript.SetSimCanvasEnabled(false);
            winScreen.SetActive(true);
        }
        else
        {
            answerWrongText.enabled = true;
        }
    }
    public void ShowReturnWarning()
    {
        simScript.SetSimCanvasEnabled(false);
        returnWarning.SetActive(true);
    }
    public void HideReturnWarning()
    {
        simScript.SetSimCanvasEnabled(true);
        returnWarning.SetActive(false);
    }
    public string[] GetQuestionUnits()
    {
        string[] units = new string[3];
        switch (arrayIndex)
        {
            case 0:
                units[0] = "Mg";
                units[1] = "kg";
                units[2] = "g";
                break;
            case 1:
                units[0] = "kg";
                units[1] = "g";
                units[2] = "mg";
                break;
            case 2:
                units[0] = "g";
                units[1] = "mg";
                units[2] = "ug";
                break;
            case 3:
                units[0] = "g";
                units[1] = "mg";
                units[2] = "ug";
                break;
            case 4:
                units[0] = "g";
                units[1] = "mg";
                units[2] = "ug";
                break;
            default:
                units[0] = "kg";
                units[1] = "g";
                units[2] = "mg";
                break;
        }
        return units;
    }
}
