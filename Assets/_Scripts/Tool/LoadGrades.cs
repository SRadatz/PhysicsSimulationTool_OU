using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class LoadGrades : MonoBehaviour
{
    private FirebaseManager firebaseManager;
    private DatabaseReference reference;
    private FirebaseAuth auth;
    private string UserId = FirebaseManager.UserID;
    private bool isTeacher = FirebaseManager.isTeacher;

    Dictionary<string, string> studentList = new Dictionary<string, string>();

    [Header("UserData")]
    public TMP_Text Student;
    public TMP_Text Module1;
    public TMP_Text Module2;
    public TMP_Text Module3;
    public TMP_Text Module4;

    [Header("UI")]
    public GameObject StudentUI;
    public GameObject TeacherUI;

    [Header("Teacher")]
    private TMP_Dropdown dropDown;

    private void Start()
    {
        firebaseManager = GetComponent<FirebaseManager>();
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        if(isTeacher == true)
        {
            StudentUI.SetActive(false);
            TeacherUI.SetActive(true);
            dropDown = GetComponent<TMP_Dropdown>();
            dropDown.options.Clear();
            StartCoroutine(LoadDropDown());
            DropdownSelect(dropDown);
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

    private IEnumerator LoadDropDown()
    {
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
                studentList.Add( childSnapshot.Child("name").Value.ToString(),childSnapshot.Child("UserID").Value.ToString() );
                dropDown.options.Add(new TMP_Dropdown.OptionData() { text = childSnapshot.Child("name").Value.ToString() });
            }
        }
    }

    void DropdownSelect(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        string studentName = dropdown.options[index].text;
        string StudentId = studentList[studentName];
        Debug.Log(StudentId);

    }
}
