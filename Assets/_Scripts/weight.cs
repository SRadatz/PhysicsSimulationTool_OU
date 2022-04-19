using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weight : MonoBehaviour
{

    //private Vector3 mousePosition;
    public float moveSpeed = 10f;
    bool follow = false;
    public int weightAmount;
    public string weightUnit;
    // Use this for initialization
    void Start()
    {
        weightAmount = int.Parse(this.transform.Find("WeightNum").GetComponent<TMP_Text>().text);
        weightUnit = this.transform.Find("WeightUnit").GetComponent<TMP_Text>().text;
        //Debug.Log(weightAmount);
        //Debug.Log(weightUnit);
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            //transform.position = mousePosition;

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float tmpx = Mathf.Clamp(worldPosition.x, 650f, 1650f);
            float tmpy = Mathf.Clamp(worldPosition.y, 150f, 850f);
            Vector2 tmpPos = new Vector2(tmpx, tmpy);
            transform.position = tmpPos;
        }


    }
    void OnMouseDown()
    {
        //Debug.Log("Clicked");
        this.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(waiter());
        follow = !follow;
        if (follow)
        {
            
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            //StartCoroutine(waiter());
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        this.GetComponent<BoxCollider2D>().enabled = true;

    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime((float)0.02);
        

    }
    public int GetWeightAmount()
    {
        return weightAmount;
    }
    public string GetWeightUnit()
    {
        return weightUnit;
    }
}
