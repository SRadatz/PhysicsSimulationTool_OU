using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AvgVeloCalculator : MonoBehaviour
{
    private float _aPos;
    private float _aTime;
    private float _bPos;
    private float _bTime;

    private float test;

    private float _avgVelocity;

    [SerializeField] private TMP_Text _calcOutput;

    [SerializeField] private GameObject AMarker;
    private RectTransform AMarkerRT;

    [SerializeField] private GameObject BMarker;
    private RectTransform BMarkerRT;
   
    [SerializeField] private GameObject Particle;
    private RectTransform ParticleRT;
    
    [SerializeField] private GameObject LeftArrow;
    [SerializeField] private GameObject RightArrow;

    public void ReadAPosInput(string s){
        if(float.TryParse(s, out float test)){
            _aPos = test;
        }
    }

    public void ReadATimeInput(string s){
        if(float.TryParse(s, out float test)){
            _aTime = test;
        }
    }

    public void ReadBPosInput(string s){
        if(float.TryParse(s, out float test)){
            _bPos = test;
        }
    }

    public void ReadBTimeInput(string s){
       if(float.TryParse(s, out float test)){
            _bTime = test;
        }
    }

    public void CalcAvgVelocity(){

        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
        
        _avgVelocity = (_bPos - _aPos)/(_bTime - _aTime);
        _avgVelocity = Mathf.Round(_avgVelocity * 100f) / 100f;

        _calcOutput.text = "Average Velocity: " + _avgVelocity + " m/s";

        // move marker a
        AMarker.SetActive(true);
        AMarkerRT = AMarker.GetComponent<RectTransform>();
        Vector3 newAMarkerPos = new Vector3(_aPos * 10, -125, 0);
        AMarkerRT.localPosition = newAMarkerPos;

        // move marker b
        BMarker.SetActive(true);
        BMarkerRT = BMarker.GetComponent<RectTransform>();
        Vector3 newBMarkerPos = new Vector3(_bPos * 10, -125, 0);
        BMarkerRT.localPosition = newBMarkerPos;

        // move particle
        Particle.SetActive(true);
        ParticleRT = Particle.GetComponent<RectTransform>();
        Vector3 newParticlePos = new Vector3(_aPos * 10, 125, 0);
        ParticleRT.localPosition = newParticlePos;

        if (_aPos < _bPos){
            RightArrow.SetActive(true);
        } 
        else if (_aPos > _bPos){
            LeftArrow.SetActive(true);
        }

    }

}
