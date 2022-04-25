using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizScoreSave : MonoBehaviour
{
    private FirebaseManager firebaseManager;
    private DatabaseReference reference;
    private FirebaseAuth auth;
    private string UserId = FirebaseManager.UserID;

    public TMP_Text score;

    private void Start()
    {
        firebaseManager = GetComponent<FirebaseManager>();
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveMod1()
    {
        StartCoroutine(SaveGradeMod1(int.Parse(score.text)));
    }


    private IEnumerator SaveGradeMod1(int score)
    {

        var DBTask = reference.Child("users").Child(UserId).Child("Mod1grade").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Module 1 Grade updated");
        }
    }

    public void SaveMod2()
    {
        StartCoroutine(SaveGradeMod2(int.Parse(score.text)));
    }


    private IEnumerator SaveGradeMod2(int score)
    {

        var DBTask = reference.Child("users").Child(UserId).Child("Mod2grade").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Module 1 Grade updated");
        }
    }

    public void SaveMod3()
    {
        StartCoroutine(SaveGradeMod3(int.Parse(score.text)));
    }


    private IEnumerator SaveGradeMod3(int score)
    {

        var DBTask = reference.Child("users").Child(UserId).Child("Mod3grade").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Module 1 Grade updated");
        }
    }

    public void SaveMod4()
    {
        StartCoroutine(SaveGradeMod4(int.Parse(score.text)));
    }


    private IEnumerator SaveGradeMod4(int score)
    {

        var DBTask = reference.Child("users").Child(UserId).Child("Mod4grade").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Module 1 Grade updated");
        }
    }
}
