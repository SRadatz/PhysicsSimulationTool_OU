using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mod2Ex1Quiz : MonoBehaviour
{
    // vars for vel calculation and testing user input
    private float _userInput;
    private float _answer;
    private float _test;

    private float _aPos;
    private float _aTime;
    private float _bPos;
    private float _bTime;

    // display txt for user
    [SerializeField] private TMP_Text _quizText;

    // gos to hold different screens
    [SerializeField] private GameObject SimScreen;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject WarningScreen;

    // gos and rts for positioning ui
    [SerializeField] private GameObject AMarker;
    private RectTransform AMarkerRT;

    [SerializeField] private GameObject BMarker;
    private RectTransform BMarkerRT;
   
    [SerializeField] private GameObject Particle;
    private RectTransform ParticleRT;
    
    [SerializeField] private GameObject LeftArrow;
    [SerializeField] private GameObject RightArrow;    
    
    private void Awake() {
        
        _aPos = Random.Range(-50, 50);
        _aTime = 0;
        _bPos = Random.Range(-50, 50);
        _bTime = Random.Range(1,25);

        //float x = _bPos - _aPos;
        //float y = _bTime - _aTime;

        _answer = (_bPos - _aPos)/(_bTime - _aTime);
        _answer = Mathf.Round(_answer * 100f) / 100f;

        _quizText.text = "A particle is moving in one dimension. At time " + _aTime + "s it is at position " + _aPos
        + "m and at time " + _bTime + "s it is at position " + _bPos + "m. Calculate the average velocity of the particle."
        + " (Round to the nearest hundredths place when necessary.)";
       

        // move marker a
        AMarkerRT = AMarker.GetComponent<RectTransform>();
        Vector3 newAMarkerPos = new Vector3(_aPos * 10, -125, 0);
        AMarkerRT.localPosition = newAMarkerPos;

        // move marker b
        BMarkerRT = BMarker.GetComponent<RectTransform>();
        Vector3 newBMarkerPos = new Vector3(_bPos * 10, -125, 0);
        BMarkerRT.localPosition = newBMarkerPos;

        // move particle
        ParticleRT = Particle.GetComponent<RectTransform>();
        Vector3 newParticlePos = new Vector3(_aPos * 10, 125, 0);
        ParticleRT.localPosition = newParticlePos;
        Debug.Log(" new local postion " + ParticleRT.localPosition);

        //test if b is on left or right and draw arrow
        // ***** currently nothing to check if apos is equal to bpos 
        if (_aPos < _bPos){
            RightArrow.SetActive(true);
        } 
        else if (_aPos > _bPos){
            LeftArrow.SetActive(true);
        }

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
