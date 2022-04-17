using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("Login");
    }

    public void LoadProfilePage()
    {
        SceneManager.LoadScene("ProfilePage");
    }
    public void LoadSceneByName(string x)
    {
        SceneManager.LoadScene(x);
    }
    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
    }
    //public void LoadSceneByName(string sceneToLoadName){
    //    Time.timeScale = 1;
    //    SceneManager.LoadScene(sceneToLoadName);
    //}


}
