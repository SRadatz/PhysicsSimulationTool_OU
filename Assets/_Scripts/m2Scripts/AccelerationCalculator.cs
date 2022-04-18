using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AccelerationCalculator : MonoBehaviour
{
    private float _initVel;
    private float _finVel;
    private float _time;
    //private float _initPos;

    private float test;

    private float _velSum;

    private float _acc;
    private float _dist;

    [SerializeField] private TMP_Text _accelerationOutput;
    [SerializeField] private TMP_Text _distanceOutput;

    [SerializeField] private TMP_Text _initVelDisp;
    [SerializeField] private TMP_Text _timeIntDisp;

    // graphic game objects here

    public void ReadInitVelInput(string s){
        if(float.TryParse(s, out float test)){
            _initVel = test;
        }
    }

    public void ReadTimeInput(string s){
        if(float.TryParse(s, out float test)){
            _time = test;
        }
    }

    public void CalcResults(){

        _initVelDisp.text = "" + _initVel;
        _timeIntDisp.text = "" + _time;
        

        // acceleration
        _finVel = 0;
        //_initPos = 0;

        _acc = (_finVel - _initVel)/(_time);
        _acc = Mathf.Round(_acc * 100f) / 100f;

        _accelerationOutput.text = "Acceleration: " + _acc + " m/s^2";

        // distance
        //_dist = ( _initPos + ((1/2) * (_initVel + _finVel) * _time) );
        //Debug.Log(_dist);
        //_dist = ((1/2) * (_initVel + _finVel) * _time);
        //Debug.Log(_dist);
        //_dist = Mathf.Round(_dist * 100f) / 100f;
        //Debug.Log(_dist);

        Debug.Log("time: " + _time);
        _velSum = _initVel + _finVel;
        Debug.Log(_velSum);
        
        _dist = (_velSum * _time)/2;
        Debug.Log(_dist);

        _distanceOutput.text = "Distance Needed to Stop: " + _dist + " m";
    }
}
