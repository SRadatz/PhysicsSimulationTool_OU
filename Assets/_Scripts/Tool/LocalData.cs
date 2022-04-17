using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;

public class LocalData : MonoBehaviour
{
    private FirebaseManager firebaseManager;
    private DatabaseReference reference;
    private FirebaseAuth auth;
    private string UserId = FirebaseManager.UserID;

    [Header("UserData")]
    public TMP_InputField nameField;
    public TMP_InputField emailField;
    public TMP_InputField StudentIDField;

    private void Start()
    {
        firebaseManager = GetComponent<FirebaseManager>();
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        LoadData();
    }
    public void LoadData()
    {
        StartCoroutine(LoadUserData());
    }
    public void SaveDataButton()
    {
        StartCoroutine(UpdateUsernameDatabase(nameField.text));
        StartCoroutine(UpdateEmail(emailField.text));
        StartCoroutine(UpdateStudentID(StudentIDField.text));
    }

    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        
        var DBTask = reference.Child("users").Child(UserId).Child("name").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.Log($"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Username updated");
        }
    }

    private IEnumerator UpdateEmail(string _email)
    {
        //Set the currently logged in user xp
        var DBTask = reference.Child("users").Child(UserId).Child("email").SetValueAsync(_email);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Email updated");
        }
    }
    private IEnumerator UpdateStudentID(string _ID)
    {
        //Set the currently logged in user kills
        var DBTask = reference.Child("users").Child(UserId).Child("sid").SetValueAsync(_ID);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("StudentID updated");
        }
    }

    private IEnumerator LoadUserData()
    {
        Debug.Log("DB reference " + reference + "UserID " + UserId);
        //Get the currently logged in user data
        var DBTask = reference.Child("users").Child(UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists
            nameField.text = "";
            emailField.text = "";
            StudentIDField.text = "";
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            nameField.text = snapshot.Child("name").Value.ToString();
            emailField.text = snapshot.Child("email").Value.ToString();
            StudentIDField.text = snapshot.Child("sid").Value.ToString();
        }
    }

    public void SignOutButton()
    {
        auth.SignOut();
    }
} 