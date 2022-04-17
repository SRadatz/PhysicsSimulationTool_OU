using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject UserDataUI;
    public GameObject LoadingUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("This already exists, destroying");
            Destroy(this);
        }
    }

    public void LoginScreen()
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        LoadingUI.SetActive(false);
        UserDataUI.SetActive(false);
    }
    public void RegisterScreen()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        LoadingUI.SetActive(false);
        UserDataUI.SetActive(false);
    }

    public void UserDataScreen()
    {
        UserDataUI.SetActive(true);
        LoadingUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
    }

    public void LoadingScreen()
    {
        LoadingUI.SetActive(true);
        UserDataUI.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
    }
}
