using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Mod2Ex3Quiz : MonoBehaviour
{
    
    private double _userInput;
    private double _answer;
    private double _test;

    private double _initVel;
    private double _initHeight;
    private double _timeMaxHeight;
    private double _timeMaxHeightAfterRound;
    private double _maxHeight;
    private double _maxHeightAfterRound;
    private double _grav = -9.8;

    [SerializeField] private TMP_Text _initVelDisp;
    [SerializeField] private TMP_Text _initHeightDisp;
    [SerializeField] private TMP_Text _maxHeightDisp;

    [SerializeField] private TMP_Text _quizText;

    [SerializeField] private GameObject SimScreen;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject WarningScreen;

    private void Awake(){

        _initVel = Random.Range(10, 100);
        _initHeight = Random.Range(40, 100);

        _initVelDisp.text = _initVel + " m/s";
        _initHeightDisp.text = _initHeight + " m";

        _timeMaxHeight = (0 - _initVel) / (_grav);
        _timeMaxHeightAfterRound = System.Math.Round(_timeMaxHeight, 2);

        _maxHeight = 0 + (_initVel * _timeMaxHeight) + ((0.5) * (-9.8) * (_timeMaxHeight * _timeMaxHeight));
        _maxHeightAfterRound = System.Math.Round(_maxHeight, 2);

        _maxHeightDisp.text = (_maxHeightAfterRound + _initHeight) + " m"; 

        _quizText.text = "A particle is \"thrown\" straight upward at an initial velocity of "
        + _initVel + " m/s from a height of " + _initHeight + " m above the ground. At what time does" 
        + " the particle reach its max height?";

        _answer = _timeMaxHeight;
    }

    public void ReadeUserInput(string s){
        if(double.TryParse(s, out double _test)){
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
