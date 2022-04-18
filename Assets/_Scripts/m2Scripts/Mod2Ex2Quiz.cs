using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mod2Ex2Quiz : MonoBehaviour
{
    // vars for calcs
    private float _userInput;
    private float _answer;
    private float _test;

    private float _initVel;
    private float _finVel;
    private float _time;
    //private float _initPos;

    private float _velSum;

    private float _acc;


    // display txt for user
    [SerializeField] private TMP_Text _quizText;

    // gos to hold different screens
    [SerializeField] private GameObject SimScreen;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject WarningScreen;

    // diplays for the sim screen
    [SerializeField] private TMP_Text _initVelDisp;
    [SerializeField] private TMP_Text _timeIntDisp;

    private void Awake(){

        // generate the init vel and time interval
        _initVel = Random.Range(10,100);
        _finVel = 0;
        _time = Random.Range(2,30);
        //_initPos = 0;

        _answer = (_finVel - _initVel)/(_time);
        _answer = Mathf.Round(_acc * 100f) / 100f;

        _quizText.text = "A particle is moving at an initial velocity of " + _initVel + " m/s"
        + " and is brought to stop over " + _time + " seconds. Find the acceleration of the particle.";

    } 

    public void ReadeUserInput(string s){
        if(float.TryParse(s, out float _test)){
            _userInput = _test;
        }
        Debug.Log("userInput: " + _userInput);
    }

    public void CompareResult(){
        if(_userInput == _answer){
            Debug.Log("Correct Answer!");
            SimScreen.SetActive(false);
            WinScreen.SetActive(true);
        } else {
            Debug.Log("Answer was incorrect");
        }
    }

    public void ShowWarning(){
        SimScreen.SetActive(false);
        WarningScreen.SetActive(true);
    }

    public void ReturnToQuiz(){
        WarningScreen.SetActive(false);
        SimScreen.SetActive(true);
    }
    
}
