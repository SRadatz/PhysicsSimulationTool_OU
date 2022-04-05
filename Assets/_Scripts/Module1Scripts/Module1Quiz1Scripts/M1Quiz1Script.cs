using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1Quiz1Script : MonoBehaviour
{
    // Start is called before the first frame update
    string question1 = "What combination of units adds up to ";
    string[] question1Prompts = new string[] { "2.143243Mg", "653.0004kg", "322.19242g", "23.1002g", "917.3131g" };
    string[] question1CorrectAnswers = { "2,143kg + 243g", "653,000g + 400mg", "322,192mg + 420ug", "23,100mg + 200ug", "917,313ug + 100ug" };
    string[] question1WrongAnswer1 = { "21,432kg + 43g", "65,300g + 40mg", "3,221,924mg + 20ug", "231,000mg + 2000ug", "91,731ug + 3100ug" };
    string[] question1WrongAnswer2 = { "214,324kg + 3g", "6,530g + 400mg", "32,219mg + 2420ug", "2,310mg + 2000ug", "9,173,100ug + 31ug" };
    string[] question1WrongAnswer3 = { "0.2143243kg", "653,400g", "322,192mg + 4,200ug", "231,020mg + 2ug", "9,173ug + 1310ug" };
    int arrayIndex;
    int prevIndex = -1;
    void Start()
    {
        //arrayIndex = Random.Range(0, 4);

        //Debug.Log(arrayIndex);
    }

    // Update is called once per frame
    void Update()
    {
        //arrayIndex = Random.Range(0, 4);
        //Debug.Log(arrayIndex);
    }
    public void setArrayIndex()
    {
        arrayIndex = Random.Range(0, 4);
        Debug.Log(arrayIndex);
    }
    public string GetQuestionNumber()
    {
        string questionNum = "";
        Debug.Log(arrayIndex + " case statement");
        switch (arrayIndex)
        {
            case 0:
                questionNum = "2.143243Mg";
                break;
            case 1:
                questionNum = "653.0004kg";
                break;
            case 2:
                questionNum = "322.19242g";
                break;
            case 3:
                questionNum = "23.1002g";
                break;
            case 4:
                questionNum = "917.3131g";
                break;
            default:
                questionNum = "???";
                break;
        }
        return questionNum;
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
