using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExerciseTwoSimScript : MonoBehaviour
{
    [SerializeField] GameObject SigFigHelp;
    [SerializeField] GameObject SimCanvas;

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

    [SerializeField] TMP_Text HintTxt;

    [SerializeField] GameObject DigitCheckmark1;
    [SerializeField] GameObject DigitCheckmark2;
    [SerializeField] GameObject DigitCheckmark3;
    [SerializeField] GameObject DigitCheckmark4;
    [SerializeField] GameObject DigitCheckmark5;
    [SerializeField] GameObject DigitCheckmark6;
    [SerializeField] GameObject DigitCheckmark7;
    [SerializeField] GameObject DigitCheckmark8;
    [SerializeField] GameObject DigitCheckmark9;
    [SerializeField] GameObject DigitCheckmark10;
    [SerializeField] GameObject DigitCheckmark11;
    [SerializeField] GameObject DigitCheckmark12;

    [SerializeField] GameObject DigitXMark1;
    [SerializeField] GameObject DigitXMark2;
    [SerializeField] GameObject DigitXMark3;
    [SerializeField] GameObject DigitXMark4;
    [SerializeField] GameObject DigitXMark5;
    [SerializeField] GameObject DigitXMark6;
    [SerializeField] GameObject DigitXMark7;
    [SerializeField] GameObject DigitXMark8;
    [SerializeField] GameObject DigitXMark9;
    [SerializeField] GameObject DigitXMark10;
    [SerializeField] GameObject DigitXMark11;
    [SerializeField] GameObject DigitXMark12;

    int[] sigFigQuestions = new int[] {6, 8, 4, 5, 7, 5, 10, 6};
    string [] prompts = new string[] {"Average velocity of a car having traveled 8.4km in 2.03s", "Force on a 12.34kg block accelerating at 5.242m/s", "Launch speed of a ball thrown at a 54 degree angle traveling 24m in 2.2s",
        "Revolutions per second required to give an astronaut of 29.4m/s in a circular motion w/ 9.45m radius", "Speed of a wrecking ball rotating counterclockwise with (-22/5i + 20.2j)m/s/s acceleration",
        "Maximum speed a light truck can go around a 75m radius curve at 32m/s", "Initial speed a 2m tall basketball player standing 10m from a 3.05m hoop must throw the ball to get nothing but net.", 
        "Speed of the Vomit Comet astronaut training craft flying at 143ms at 45 degrees heading upward"};
    string [] promptAnswers = new string[] { "0004.13793103", "0064.68628000", "0018.14602160", "0000.28075268", "0006.67008246", "0022.62741700", "0010.66395800", "0101.11627000" };
    string [] promptAnswerUnits = new string [] {"km/s", "N", "m/s", "rps", "m/s", "m/s", "m/s", "m/s"};
    int arrayIndex = 1;
    int prevIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePrompt();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratePrompt()
    {
        while(arrayIndex == prevIndex)
            arrayIndex = Random.Range(0, 8);
        prevIndex = arrayIndex;
        //Ensure all check's and x's are invisible
        DigitCheckmark1.SetActive(false);
        DigitCheckmark2.SetActive(false);
        DigitCheckmark3.SetActive(false);
        DigitCheckmark4.SetActive(false);
        DigitCheckmark5.SetActive(false);
        DigitCheckmark6.SetActive(false);
        DigitCheckmark7.SetActive(false);
        DigitCheckmark8.SetActive(false);
        DigitCheckmark9.SetActive(false);
        DigitCheckmark10.SetActive(false);
        DigitCheckmark11.SetActive(false);
        DigitCheckmark12.SetActive(false);

        DigitXMark1.SetActive(false);
        DigitXMark2.SetActive(false);
        DigitXMark3.SetActive(false);
        DigitXMark4.SetActive(false);
        DigitXMark5.SetActive(false);
        DigitXMark6.SetActive(false);
        DigitXMark7.SetActive(false);
        DigitXMark8.SetActive(false);
        DigitXMark9.SetActive(false);
        DigitXMark10.SetActive(false);
        DigitXMark11.SetActive(false);
        DigitXMark12.SetActive(false);
        
        //set text boxes to display proper information
        FindSigFigTxt.text = "Find the " + sigFigQuestions[arrayIndex] + "th Significant Figure in the prompt below";
        HintTxt.text = "";
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
    public void CheckAnswer(int btnPressed)
    {
        switch(arrayIndex)
        {
            //0004.13793103
            case 0:
                switch(btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //not a sig fig
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 4:
                        //sig fig 1
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 5:
                        //sig fig 2
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 6:
                        //sig fig 3
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 7:
                        //sig fig 4
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 8:
                        //sig fig 5
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 9:
                        //sig fig 6
                        //correct
                        DigitCheckmark9.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 6th sig fig, the answer would be 4.13793";
                        break;
                    case 10:
                        //sig fig 7
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 11:
                        //sig fig 8
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 12:
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        //sig fig 9
                        break;

                }
                break;
            //0064.68628000
            case 1:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //not a sig fig
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 4:
                        //sig fig 1
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 5:
                        //sig fig 2
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 6:
                        //sig fig 3
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 7:
                        //sig fig 4
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 8:
                        //sig fig 5
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 9:
                        //sig fig 7
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 10:
                        //sig fig 8
                        //correct
                        DigitCheckmark10.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 8th sig fig, the answer would be 64.686280";
                        break;
                    case 11:
                        //sig fig 8
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 12:
                        //sig fig 9
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;

                }
                break;
            //0018.14602160
            case 2:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //sig fig 1
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 4:
                        //sig fig 2
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 5:
                        //sig fig 3
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 6:
                        //sig fig 4
                        //correct
                        DigitCheckmark6.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 18.14";
                        break;
                    case 7:
                        //sig fig 5
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 8:
                        //sig fig 6
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 9:
                        //sig fig 7
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 10:
                        //sig fig 8
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 11:
                        //sig fig 9
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 12:
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        //sig fig 10
                        break;

                }
                break;
            //0000.28075268
            case 3:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //not a sig fig
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 4:
                        //not a sig fig
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 5:
                        //sig fig 1
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 6:
                        //sig fig 2
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 7:
                        //sig fig 3
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 8:
                        //sig fig 4
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 9:
                        //sig fig 5
                        //correct
                        DigitCheckmark9.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 0.28075";
                        break;
                    case 10:
                        //sig fig 6
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 11:
                        //sig fig 7
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 12:
                        //sig fig 8
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;

                }
                break;
            //0006.67008246
            case 4:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //not a sig fig
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 4:
                        //sig fig 1
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 5:
                        //sig fig 2
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 6:
                        //sig fig 3
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 7:
                        //sig fig 4
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 8:
                        //sig fig 5
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 9:
                        //sig fig 6 
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 10:
                        //sig fig 7
                        DigitCheckmark10.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 6.670082";
                        //correct
                        break;
                    case 11:
                        //sig fig 8
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 12:
                        //sig fig 9
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;

                }
                break;
            //0022.62741700
            case 5:
                switch (btnPressed)
                {

                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //sig fig 1
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 4:
                        //sig fig 2
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 5:
                        //sig fig 3
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 6:
                        //sig fig 4   
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 7:
                        //sig fig 5
                        //correct
                        DigitCheckmark7.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 22.627";
                        break;
                    case 8:
                        //sig fig 6
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 9:
                        //sig fig 7
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 10:
                        //sig fig 8
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 11:
                        //sig fig 9
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 12:
                        //sig fig 10
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                }
                break;
            //0010.66395800
            case 6:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //not a sig fig
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 3:
                        //sig fig 1
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "You need quite a few more sig figs";
                        break;
                    case 4:
                        //sig fig 2
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "You need quite a few more sig figs";
                        break;
                    case 5:
                        //sig fig 3
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "You need quite a few more sig figs";
                        break;
                    case 6:
                        //sig fig 4   
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "You need quite a few more sig figs";
                        break;
                    case 7:
                        //sig fig 5
                        DigitXMark7.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 8:
                        //sig fig 6
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 9:
                        //sig fig 7
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 10:
                        //sig fig 8
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 11:
                        //sig fig 9
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 12:
                        //sig fig 10
                        //correct
                        DigitCheckmark12.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 10.66395800";
                        break;

                }
                break;
            //0101.1162700
            case 7:
                switch (btnPressed)
                {
                    case 1:
                        //not a sig fig
                        DigitXMark1.SetActive(true);
                        HintTxt.text = "Remember: Zeroes before the first nonzero digit before the decimal are NOT sig figs";
                        break;
                    case 2:
                        //sig fig 1
                        DigitXMark2.SetActive(true);
                        HintTxt.text = "You need quite a few more sig figs";
                        break;
                    case 3:
                        //sig fig 2
                        DigitXMark3.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 4:
                        //sig fig 3
                        DigitXMark4.SetActive(true);
                        HintTxt.text = "Not quite. That's not enough sig figs";
                        break;
                    case 5:
                        //sig fig 4
                        DigitXMark5.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 6:
                        //sig fig 5   
                        DigitXMark6.SetActive(true);
                        HintTxt.text = "Almost! You're only a bit off!";
                        break;
                    case 7:
                        //sig fig 6
                        DigitCheckmark7.SetActive(true);
                        HintTxt.text = "Correct! If we rounded to the 4th sig fig, the answer would be 101.116";
                        break;
                    case 8:
                        //sig fig 7
                        DigitXMark8.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 9:
                        //sig fig 8
                        DigitXMark9.SetActive(true);
                        HintTxt.text = "Almost! You have a bit too many sig figs!";
                        break;
                    case 10:
                        //sig fig 9
                        DigitXMark10.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 11:
                        //sig fig 10
                        DigitXMark11.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;
                    case 12:
                        //sig fig 11
                        //correct
                        DigitXMark12.SetActive(true);
                        HintTxt.text = "Not quite. That's too many sig figs";
                        break;

                }
                break;

        }
    }
    public void ShowSigFigHelp()
    {
        SimCanvas.SetActive(false);
        SigFigHelp.SetActive(true);
    }
    public void HideSigFigHelp()
    {
        SimCanvas.SetActive(true);
        SigFigHelp.SetActive(false);
    }
}
