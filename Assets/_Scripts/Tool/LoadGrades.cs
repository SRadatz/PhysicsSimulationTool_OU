using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;

public class LoadGrades : MonoBehaviour
{
    private FirebaseManager firebaseManager;
    private DatabaseReference reference;
    private FirebaseAuth auth;
    private string UserId = FirebaseManager.UserID;
    private bool isTeacher = FirebaseManager.isTeacher;

    [Header("UserData")]
    public TMP_Text Student;
    public TMP_Text Module1;
    public TMP_Text Module2;
    public TMP_Text Module3;
    public TMP_Text Module4;

    [Header("UI")]
    public GameObject StudentUI;
    public GameObject TeacherUI;

    private void Start()
    {
        firebaseManager = GetComponent<FirebaseManager>();
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        if(isTeacher == true)
        {
            StudentUI.SetActive(false);
            TeacherUI.SetActive(true);
        }
        else
        {
            StudentUI.SetActive(true);
            TeacherUI.SetActive(false);
            LoadStudentGrades();
        }
    }

    public void LoadStudentGrades()
    {
        StartCoroutine(LoadGradeData());
    }

    private IEnumerator LoadGradeData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = reference.Child("users").Child(UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists
            Student.text = "";
            Module1.text = "";
            Module2.text = "";
            Module3.text = "";
            Module4.text = "";
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            Student.text = snapshot.Child("name").Value.ToString();
            Module1.text = snapshot.Child("Mod1grade").Value.ToString();
            Module2.text = snapshot.Child("Mod2grade").Value.ToString();
            Module3.text = snapshot.Child("Mod3grade").Value.ToString();
            Module4.text = snapshot.Child("Mod4grade").Value.ToString();
        }
    }
}
