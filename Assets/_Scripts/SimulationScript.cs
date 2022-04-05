using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SimulationScript : MonoBehaviour
{
    [SerializeField] GameObject Weight;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Dropdown weightUnit;
    [SerializeField] TMP_Dropdown scaleUnit;
    [SerializeField] TMP_InputField weightAmount;
    [SerializeField] TMP_Text scaleReading;

    Transform weightObjectUnit;
    Transform weightObjectAmount;
    String currentUnit;
    // Start is called before the first frame update
    void Start()
    {
        scaleReading.text = "0000.000" + scaleUnit.options[scaleUnit.value].text;
        currentUnit = scaleUnit.options[scaleUnit.value].text;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddWeight()
    {
        //Debug.Log("click");
        GameObject weight = Instantiate(Weight, new Vector3(813f, 328f, 1f), Quaternion.identity, canvas.transform);
        weightObjectAmount = weight.transform.Find("WeightNum");
        weightObjectUnit = weight.transform.Find("WeightUnit");
        weightObjectUnit.GetComponent<TMP_Text>().text = weightUnit.options[weightUnit.value].text;
        if (weightAmount.text != "")
            weightObjectAmount.GetComponent<TMP_Text>().text = weightAmount.text;
        else
            weightObjectAmount.GetComponent<TMP_Text>().text = "1";
        weight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }
    public void ChangeScaleUnit()
    {
        if (currentUnit == "g")
        {
            scaleReading.text = scaleReading.text.Substring(0, scaleReading.text.Length - 1) + scaleUnit.options[scaleUnit.value].text;
            //Debug.Log("True");
            currentUnit = scaleUnit.options[scaleUnit.value].text;
        }
        else
        {
            scaleReading.text = scaleReading.text.Substring(0, scaleReading.text.Length - 2) + scaleUnit.options[scaleUnit.value].text;
            currentUnit = scaleUnit.options[scaleUnit.value].text;
        }
    }
    public void ChangeScaleReading(double x)
    {
        scaleReading.text = x.ToString() + currentUnit;
    }

    public string GetCurrentUnit()
    {
        return currentUnit;
    }
    
}
