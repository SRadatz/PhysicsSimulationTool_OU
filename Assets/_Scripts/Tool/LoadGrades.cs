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
    string currentStudent;

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
    public TMP_Dropdown StudentDropdown;
    public TMP_InputField Module1Input;
    public TMP_InputField Module2Input;
    public TMP_InputField Module3Input;
    public TMP_InputField Module4Input;

    private void Start()
    {
        firebaseManager = GetComponent<FirebaseManager>();
        auth = FirebaseAuth.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        if(isTeacher == true)
        {
            StudentUI.SetActive(false);
            TeacherUI.SetActive(true);
            StartCoroutine(LoadDropDown());

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
        //StudentDropdown.options.Clear();
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
                Debug.Log(childSnapshot.Child("name").Value.ToString()+ " + " + childSnapshot.Child("UserID").Value.ToString());
                StudentDropdown.options.Add(new TMP_Dropdown.OptionData() { text = childSnapshot.Child("name").Value.ToString() });
            }
        }

        StudentDropdown.onValueChanged.AddListener(delegate { DropdownSelect(StudentDropdown); });
    }

    void DropdownSelect(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        if (index != 0)
        {
            string studentName = dropdown.options[index].text;
            string StudentId = studentList[studentName];
            Debug.Log(StudentId);
            StartCoroutine(TeacherLoadGradeData(StudentId));
            currentStudent = StudentId;
        }
        else
        {
            //Don't want to use the select student
        }
    }

    private IEnumerator TeacherLoadGradeData(string studentID)
    {
        var DBTask = reference.Child("users").Child(studentID).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            //Student.text = snapshot.Child("name").Value.ToString();
            Module1Input.text = snapshot.Child("Mod1grade").Value.ToString();
            Module2Input.text = snapshot.Child("Mod2grade").Value.ToString();
            Module3Input.text = snapshot.Child("Mod3grade").Value.ToString();
            Module4Input.text = snapshot.Child("Mod4grade").Value.ToString();

            //nameField.text = snapshot.Child("name").Value.ToString();
        }
    }

    public void UpdateGrades()
    {
        StartCoroutine(Mod1Grade(int.Parse(Module1Input.text), currentStudent));
        StartCoroutine(Mod2Grade(int.Parse(Module2Input.text), currentStudent));
        StartCoroutine(Mod3Grade(int.Parse(Module3Input.text), currentStudent));
        StartCoroutine(Mod4Grade(int.Parse(Module4Input.text), currentStudent));
        //warning.text = "Information Updated";
    }

    private IEnumerator Mod1Grade(int grade, string uid)
    {

        var DBTask = reference.Child("users").Child(uid).Child("Mod1grade").SetValueAsync(grade);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Module 1 updated");
        }
    }

    private IEnumerator Mod2Grade(int grade, string uid)
    {

        var DBTask = reference.Child("users").Child(uid).Child("Mod2grade").SetValueAsync(grade);

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

    private IEnumerator Mod3Grade(int grade, string uid)
    {

        var DBTask = reference.Child("users").Child(uid).Child("Mod3grade").SetValueAsync(grade);

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

    private IEnumerator Mod4Grade(int grade, string uid)
    {

        var DBTask = reference.Child("users").Child(uid).Child("Mod4grade").SetValueAsync(grade);

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
}
