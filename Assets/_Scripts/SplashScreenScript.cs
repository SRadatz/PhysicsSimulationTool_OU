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
        yield return new WaitForSecondsRealtime(3);
        sceneLoader.LoadMainMenuScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
