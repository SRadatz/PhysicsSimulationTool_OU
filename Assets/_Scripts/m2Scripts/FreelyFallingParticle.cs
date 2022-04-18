using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FreelyFallingParticle : MonoBehaviour
{
    private double _initVel;
    private double _initHeight;
    private double _timeMaxHeight;
    private double _timeMaxHeightAfterRound;
    private double _maxHeight;
    private double _maxHeightAfterRound;
    private double _grav = -9.8;

    private double test;
    private double _runningSum;

    [SerializeField] private TMP_Text _timeMaxHeightOutput;
    [SerializeField] private TMP_Text _maxHeightOutput;

    [SerializeField] private TMP_Text _initVelDisp;
    [SerializeField] private TMP_Text _initHeightDisp;
    [SerializeField] private TMP_Text _maxHeightDisp;

    public void ReadInitVelInput(string s){
        if(double.TryParse(s, out double test)){
            _initVel = test;
        }
    }

    public void ReadInitHeightInput(string s){
        if(double.TryParse(s, out double test)){
            _initHeight = test;
        }
    }

    public void CalcResults(){

        _initVelDisp.text = _initVel + " m/s";
        _initHeightDisp.text = _initHeight + " m";

        // calc time at max height
        _timeMaxHeight = (0 - _initVel) / (_grav);
        _timeMaxHeightAfterRound = Math.Round(_timeMaxHeight, 2);

        _timeMaxHeightOutput.text = "Time of Max Height: " + _timeMaxHeightAfterRound + " s";

        // calc max height
        
        _maxHeight = 0 + (_initVel * _timeMaxHeight) + ((0.5) * (-9.8) * (_timeMaxHeight * _timeMaxHeight));
        _maxHeightAfterRound = Math.Round(_maxHeight, 2);

        _maxHeightDisp.text = (_maxHeightAfterRound + _initHeight) + " m";
        _maxHeightOutput.text = "Max Height: " + (_maxHeightAfterRound + _initHeight) + " m";

    }
    
}
