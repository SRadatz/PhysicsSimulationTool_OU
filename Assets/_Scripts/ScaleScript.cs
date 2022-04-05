using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScaleScript : MonoBehaviour
{


    //[SerializeField] TMP_Text scaleReadingTxt;
    [SerializeField] SimulationScript SimulationScript;
    double scaleReading = 0;
    Collider2D[] colliders = new Collider2D[10];
    int numColliders = 0;
    
    //string weightUnit = weight.GetWeightUnit();
    //int weightAmount = weight.GetWeightAmount();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<BoxCollider2D>().IsTouchingLayers(Physics2D.AllLayers) == false)
        {
            SimulationScript.ChangeScaleReading(0);
            scaleReading = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weight")
        {
            //Debug.Log(collision.gameObject.GetComponent<weight>().weightAmount.ToString());
            //weight collisionWeight = collision.gameObject.GetComponent<weight>();
            AddWeight((double)collision.gameObject.GetComponent<weight>().weightAmount, collision.gameObject.GetComponent<weight>().weightUnit);
            SimulationScript.ChangeScaleReading(scaleReading);

        }
        else
        {
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weight")
        {
            //Debug.Log(collision.gameObject.GetComponent<weight>().weightAmount.ToString());
            //weight collisionWeight = collision.gameObject.GetComponent<weight>();
            SubtractWeight((double)collision.gameObject.GetComponent<weight>().weightAmount, collision.gameObject.GetComponent<weight>().weightUnit);
            SimulationScript.ChangeScaleReading(scaleReading);

        }
        else
        {
        }
    }
    public void Recalculate()
    {
        scaleReading = 0;
        ContactFilter2D contactFilter = new ContactFilter2D();
        numColliders = this.gameObject.GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, colliders);
        //Debug.Log(colliders.Length);
        int i = 0;
        //Debug.Log("Weight amount = " + colliders[i].gameObject.GetComponent<weight>().weightAmount);
        while (colliders[i] != null)
        {
            Debug.Log("Weight amount = " + colliders[i].gameObject.GetComponent<weight>().weightAmount);
            AddWeight((double)colliders[i].gameObject.GetComponent<weight>().weightAmount, colliders[i].gameObject.GetComponent<weight>().weightUnit);
            i++;
        }
        SimulationScript.ChangeScaleReading(scaleReading);
    }
    private void AddWeight(double weightAmount, string weightUnit)
    {
        
        string currentUnit = SimulationScript.GetCurrentUnit();
        Debug.Log("current unit: " + currentUnit + ", weight amount: " + weightAmount + ", weight unit: " + weightUnit);
        switch(currentUnit)
        {
            case "Mg":
                //Debug.Log("scale switch=  Mg");
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading += weightAmount;
                        break;
                    case "kg":
                        //Debug.Log("Added weight: " + (weightAmount / 1000));
                        scaleReading += (weightAmount/1000);
                        break;
                    case "g":
                        scaleReading += (weightAmount / 1000000);
                        break;
                    case "mg":
                        scaleReading += (weightAmount / 1000000000);
                        break;
                    case "ug":
                        scaleReading += (weightAmount / 1000000000000);
                        break;
                }
                break;
            case "kg":
                Debug.Log("scale switch=  kg");
                switch (weightUnit)
                {
                    case "Mg":
                        //Debug.Log("Added weight: " + (weightAmount * 1000));
                        scaleReading += (weightAmount * 1000);
                        break;
                    case "kg":
                        scaleReading += weightAmount;
                        break;
                    case "g":
                        scaleReading += (weightAmount / 1000);
                        break;
                    case "mg":
                        scaleReading += (weightAmount / 1000000);
                        break;
                    case "ug":
                        scaleReading += (weightAmount / 1000000000);
                        break;
                }
                break;
            case "g":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading += (weightAmount * 1000000);
                        break;
                    case "kg":
                        scaleReading += (weightAmount * 1000);
                        break;
                    case "g":
                        scaleReading += weightAmount;
                        break;
                    case "mg":
                        scaleReading += (weightAmount / 1000);
                        break;
                    case "ug":
                        scaleReading += (weightAmount / 1000000);
                        break;
                }
                break;
            case "mg":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading += (weightAmount * 1000000000);
                        break;
                    case "kg":
                        scaleReading += (weightAmount * 1000000);
                        break;
                    case "g":
                        //Debug.Log("Added weight: " + (weightAmount * 1000));
                        scaleReading += (weightAmount * 1000);
                        break;
                    case "mg":
                        scaleReading += weightAmount;
                        break;
                    case "ug":
                        scaleReading += (weightAmount / 1000);
                        break;
                }
                break;
            case "ug":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading += (weightAmount * 1000000000000);
                        break;
                    case "kg":
                        scaleReading += (weightAmount * 1000000000);
                        break;
                    case "g":
                        scaleReading += (weightAmount * 1000000);
                        break;
                    case "mg":
                        //Debug.Log("Added weight: " + (weightAmount * 1000));
                        scaleReading += (weightAmount * 1000);
                        break;
                    case "ug":
                        scaleReading += weightAmount;
                        break;
                }
                break;
        }
        //Debug.Log("scale reading: " + scaleReading);

    }
    private void SubtractWeight(double weightAmount, string weightUnit)
    {

        string currentUnit = SimulationScript.GetCurrentUnit();
        //Debug.Log("current unit: " + currentUnit + ", weight amount: " + weightAmount + ", weight unit: " + weightUnit);
        switch (currentUnit)
        {
            case "Mg":
                //Debug.Log("scale switch=  Mg");
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading -= weightAmount;
                        break;
                    case "kg":
                        //Debug.Log("scale switch=  kg");
                        scaleReading -= (weightAmount / 1000);
                        break;
                    case "g":
                        scaleReading -= (weightAmount / 1000000);
                        break;
                    case "mg":
                        scaleReading -= (weightAmount / 1000000000);
                        break;
                    case "ug":
                        scaleReading -= (weightAmount / 1000000000000);
                        break;
                }
                break;
            case "kg":
                //Debug.Log("scale switch=  kg");
                switch (weightUnit)
                {
                    case "Mg":
                        //Debug.Log("Subtracted weight: " + (weightAmount * 1000));
                        scaleReading -= (weightAmount * 1000);
                        break;
                    case "kg":
                        scaleReading -= weightAmount;
                        break;
                    case "g":
                        scaleReading -= (weightAmount / 1000);
                        break;
                    case "mg":
                        scaleReading -= (weightAmount / 1000000);
                        break;
                    case "ug":
                        scaleReading -= (weightAmount / 1000000000);
                        break;
                }
                break;
            case "g":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading -= (weightAmount * 1000000);
                        break;
                    case "kg":
                        //Debug.Log("Subtracted weight: " + (weightAmount * 1000));
                        scaleReading -= (weightAmount * 1000);
                        break;
                    case "g":
                        scaleReading -= weightAmount;
                        break;
                    case "mg":
                        scaleReading -= (weightAmount / 1000);
                        break;
                    case "ug":
                        scaleReading -= (weightAmount / 1000000);
                        break;
                }
                break;
            case "mg":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading -= (weightAmount * 1000000000);
                        break;
                    case "kg":
                        scaleReading -= (weightAmount * 1000000);
                        break;
                    case "g":
                        Debug.Log("Subtracted weight: " + (weightAmount * 1000));
                        scaleReading -= (weightAmount * 1000);
                        break;
                    case "mg":
                        scaleReading -= weightAmount;
                        break;
                    case "ug":
                        scaleReading -= (weightAmount / 1000);
                        break;
                }
                break;
            case "ug":
                switch (weightUnit)
                {
                    case "Mg":
                        scaleReading -= (weightAmount * 1000000000000);
                        break;
                    case "kg":
                        scaleReading -= (weightAmount * 1000000000);
                        break;
                    case "g":
                        scaleReading -= (weightAmount * 1000000);
                        break;
                    case "mg":
                        //Debug.Log("Subtracted weight: " + (weightAmount * 1000));
                        scaleReading -= (weightAmount * 1000);
                        break;
                    case "ug":
                        scaleReading -= weightAmount;
                        break;
                }
                break;
        }
       //Debug.Log("scale reading: " + scaleReading);

    }
    
}
