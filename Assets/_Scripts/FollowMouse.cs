using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour
{

    //private Vector3 mousePosition;
    public float moveSpeed = 10f;
    bool follow = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(follow == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }


    }
    void OnMouseDown()
    {
        //Debug.Log("Clicked");
        follow = !follow;
        //while (Input.GetMouseButtonUp(0))
        //{

        //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //    transform.position = mousePosition;
        //    
        //}
    }
}
