using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DSVCalculator : MonoBehaviour
{
    // private doubles to hold val of converted strings
    private double _aPos;
    private double _aTime;
    private double _bPos;
    private double _bTime;
    private double _cPos;
    private double _cTime;

    // private doubles to return calculations
    private double _displacement;
    private double _avgVelocity;

    void Update()
    {
        CalcDisplacement();
        Debug.Log("Displacement: " + _displacement);
        CalcAvgVelocity();
        Debug.Log("Average Velocity: " + _avgVelocity);
    }

    // The following functions read user input and convert to doubles

    // dest a inputs
    public void ReadAPosInput(string s){
        _aPos = Convert.ToDouble(s);
    }

    public void ReadATimeInput(string s){
        _aTime = Convert.ToDouble(s);  
    }

    // dest b inputs
    public void ReadBPosInput(string s){
        _bPos = Convert.ToDouble(s);
    }

    public void ReadBTimeInput(string s){
        _bTime = Convert.ToDouble(s);
    }

    // dest c inputs
    public void ReadCPosInput(string s){
        _cPos = Convert.ToDouble(s);
    }

    public void ReadCTimeInput(string s){
        _cTime = Convert.ToDouble(s);
    }

    // calculate the total displacement
    public void CalcDisplacement(){
        _displacement = _cPos - _bPos - _aPos;
    }

    // calculate the average velocity
    public void CalcAvgVelocity(){
        _avgVelocity = (_cPos - _aPos)/(_cTime - _aTime);
    }

    // calculate the average speed
    public void CalcAvgSpeed(){

    }

    // the following functions perform calculations with the users input
    // move this to a button click event
    public void CalcOutput(){
        double testSum;
        testSum = _aPos + _bPos;
        // Debug.Log("A Pos: " + APosInput + "A Time: " + ATimeInput);
        // Debug.Log("Addition: " + testSum);
    }

    



}
