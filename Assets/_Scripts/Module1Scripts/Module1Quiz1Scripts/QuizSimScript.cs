using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizSimScript : MonoBehaviour
{
    [SerializeField] GameObject QuizWeight;
    [SerializeField] Canvas canvas;
    

    Transform weightObjectUnit;
    Transform weightObjectAmount;
    String currentUnit;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddWeight(string unit, float x)
    {
        //Debug.Log("click");
        GameObject weight = Instantiate(QuizWeight, new Vector3(x, 617f, 1f), Quaternion.identity, canvas.transform);
        weightObjectAmount = weight.transform.Find("QuizWeightNum");
        weightObjectAmount.GetComponent<TMP_Text>().text = "???";
        weightObjectUnit = weight.transform.Find("QuizWeightUnit");
        weightObjectUnit.GetComponent<TMP_Text>().text = unit;
        
        weight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }
    public void SetSimCanvasEnabled(bool x)
    {
        canvas.gameObject.SetActive(x);
    }
}

