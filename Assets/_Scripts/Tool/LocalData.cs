using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;

public class LocalData : MonoBehaviour
{
    private FirebaseManager firebaseManager;
    private DatabaseReference reference;
    private FirebaseAuth auth;
    private string UserId = FirebaseManager.UserID;
    private bool isTeacher = FirebaseManager.isTeacher;
    private bool nameUnique;

    [Header("UserData")]
    public TMP_InputField nameField;
    public TMP_InputField emailField;
    public TMP_InputField StudentIDField;
    public TMP_Text warning;

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
        StartCoroutine(isTeacherCheck());
    }
    public void SaveDataButton()
    {
        warning.text = "";
        string VerifyName = nameField.text;
        StartCoroutine(NameVerify(VerifyName));
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

    private IEnumerator UpdateIsTeacher(bool _isTeacher)
    {

        var DBTask = reference.Child("users").Child(UserId).Child("isTeacher").SetValueAsync(_isTeacher);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.Log($"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("isTeacher updated");
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

    public IEnumerator isTeacherCheck()
    {

        var DBTask = reference.Child("users").Child(UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {

            DataSnapshot snapshot = DBTask.Result;

            string isTeacherChek = snapshot.Child("isTeacher").Value.ToString();
            Debug.Log("isTeacherChek = " + isTeacherChek);

            if (isTeacherChek == "True")
            {
                isTeacher = true;
                FirebaseManager.isTeacher = true;
            }
            else
            {
                isTeacher = false;
                FirebaseManager.isTeacher = false;
            }
        }
    }

    public IEnumerator NameVerify(string studentName)
    {
        int namesAllowed = 1;
        int namesFound = 0;

        var DBTask = reference.Child("users").OrderByChild("name").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string checkName = childSnapshot.Child("name").Value.ToString();
                string checkUID = childSnapshot.Child("UserID").Value.ToString();
                Debug.Log(namesFound + " Names Found ///// " + nameUnique + " NameUnique Value");
                if (studentName == checkName && FirebaseManager.UserID != checkUID)
                {
                    Debug.Log(checkName + " vs " + studentName + " Dupe found");
                    namesFound += 1;                    
                }
                else
                {
                    Debug.Log(checkName + " vs " + studentName + " is unique");
                }
            }

            if(namesFound < namesAllowed)
            {
                nameUnique = true;                
            }
            else
            {
                nameUnique = false;
            }
            
            if (nameUnique == false)
            {
                warning.text = studentName + " is not a unique name";
            }
            else
            {
                StartCoroutine(UpdateUsernameDatabase(nameField.text));
                StartCoroutine(UpdateEmail(emailField.text));
                StartCoroutine(UpdateStudentID(StudentIDField.text));
                StartCoroutine(UpdateIsTeacher(isTeacher));
                warning.text = "Information Updated";
            }
        }
    }

    //public IEnumerator TableCheck()
    //{
    //
    //    var DBTask = reference.Child("users").Child(UserId).GetValueAsync();
    //
    //    yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
    //
    //    if (DBTask.Exception != null)
    //    {
    //        Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
    //    }
    //    else if (DBTask.Result.Value == null)
    //    {
    //        Debug.Log("cannot grab grades");
    //    }
    //    else
    //    {
    //
    //        DataSnapshot snapshot = DBTask.Result;
    //
    //        string nameCheck = snapshot.Child("name").Value.ToString();
    //        string emailCheck = snapshot.Child("email").Value.ToString();
    //        string sidCheck = snapshot.Child("sid").Value.ToString();
    //        string Mod1Check = snapshot.Child("Mod1grade").Value.ToString();
    //        string nameCheck = snapshot.Child("name").Value.ToString();
    //
    //
    //        if (isTeacherChek == "True")
    //        {
    //            isTeacher = true;
    //            FirebaseManager.isTeacher = true;
    //        }
    //        else
    //        {
    //            isTeacher = false;
    //            FirebaseManager.isTeacher = false;
    //        }
    //    }
    //}

    public void SignOutButton()
    {
        auth.SignOut();
    }
} 