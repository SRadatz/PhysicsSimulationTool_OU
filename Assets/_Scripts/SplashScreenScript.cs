using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SceneLoader sceneLoader;
    void Start()
    {
        StartCoroutine(waiter());
        
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        sceneLoader.LoadSceneByName("Login");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
