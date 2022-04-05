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
    [SerializeField] M1Quiz1Script quizScript;
    [SerializeField] TMP_Text scaleReading;

    Transform weightObjectUnit;
    Transform weightObjectAmount;
    String currentUnit;
    // Start is called before the first frame update
    void Start()
    {
        setScaleReading();


    }

    // Update is called once per frame
    void Update()
    {

    }
    void setScaleReading()
    {
        quizScript.setArrayIndex();
        scaleReading.text = quizScript.GetQuestionNumber();
    }
    public void AddWeight(string unit)
    {
        //Debug.Log("click");
        GameObject weight = Instantiate(QuizWeight, new Vector3(813f, 328f, 1f), Quaternion.identity, canvas.transform);
        weightObjectAmount = weight.transform.Find("WeightNum");
        weightObjectAmount.GetComponent<TMP_Text>().text = "???";
        weightObjectUnit = weight.transform.Find("WeightUnit");
        weightObjectUnit.GetComponent<TMP_Text>().text = unit;
        
        weight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }
    //public void ChangeScaleUnit()
    //{
    //    if (currentUnit == "g")
    //    {
    //        scaleReading.text = scaleReading.text.Substring(0, scaleReading.text.Length - 1) + scaleUnit.options[scaleUnit.value].text;
    //        //Debug.Log("True");
    //        currentUnit = scaleUnit.options[scaleUnit.value].text;
    //    }
    //    else
    //    {
    //        scaleReading.text = scaleReading.text.Substring(0, scaleReading.text.Length - 2) + scaleUnit.options[scaleUnit.value].text;
    //        currentUnit = scaleUnit.options[scaleUnit.value].text;
    //    }
    //}
    //public void ChangeScaleReading(double x)
    //{
    //    scaleReading.text = x.ToString() + currentUnit;
    //}

    //public string GetCurrentUnit()
    //{
    //    return currentUnit;
    //}   
}

