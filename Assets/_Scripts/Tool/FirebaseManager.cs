using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;

public class FirebaseManager : Singleton<FirebaseManager>
{
    SceneLoader Loader;
 
    [Header("Firebase")]
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DependencyStatus dependencyStatus;
    public DatabaseReference DBreference;
    public static string UserID;

    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text loginWarningText;
    public TMP_Text loginConfirmText;

    [Header("Register")]
    public TMP_InputField usernameRegField;
    public TMP_InputField emailRegField;
    public TMP_InputField passwordRegField;
    public TMP_InputField passwordRegVerifyField;
    public TMP_Text warningRegText;

    [Header("UserData")]
    public TMP_InputField nameField;
    public TMP_InputField emailField;
    public TMP_InputField StudentIDField;
    public GameObject scoreElement;
    public Transform scoreboardContent;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }

        });
    }

    private void InitFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Firebase Auth Setup");
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SignOutButton()
    {
        auth.SignOut();
        UIManager.instance.LoginScreen();
        usernameRegField.text = "";
        emailRegField.text = "";
        passwordRegField.text = "";
        passwordRegVerifyField.text = "";
        emailLoginField.text = "";
        passwordLoginField.text = "";
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegField.text, passwordRegField.text, usernameRegField.text));
    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }

    public void SaveDataButton()
    {
        StartCoroutine(UpdateUsernameAuth(nameField.text));
        StartCoroutine(UpdateUsernameDatabase(nameField.text));

        StartCoroutine(UpdateEmail(emailField.text));
        StartCoroutine(UpdateStudentID(StudentIDField.text));
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            warningRegText.text = "Missing Username";
        }
        else if (passwordRegField.text != passwordRegVerifyField.text)
        {
            warningRegText.text = "Password Does Not Match!";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegText.text = message;
            }
            else
            {
                User = RegisterTask.Result;

                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegText.text = "Username Set Failed!";
                    }
                    else
                    {
                        UIManager.instance.LoginScreen();
                        warningRegText.text = "";
                    }
                }
            }
        }
    }

    //login funtion
    private IEnumerator Login(string _email, string _password)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            loginWarningText.text = message;
        }
        else
        {
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            loginWarningText.text = "";
            loginConfirmText.text = "Logged In";
            StartCoroutine(LoadUserData());
            UserID = User.UserId;

            yield return new WaitForSeconds(1);

            //Loader.LoadSceneByName("ProfilePage");

            //nameField.text = User.DisplayName;
            UIManager.instance.LoadingScreen();
            //UIManager.instance.UserDataScreen();
            loginConfirmText.text = "";
        }
    }

    private IEnumerator UpdateUsernameAuth(string _username)
    {
        
        UserProfile profile = new UserProfile { DisplayName = _username };

        
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            
        }
    }

    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("name").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("Username updated");
        }
    }

    private IEnumerator UpdateEmail(string _email)
    {
        
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("email").SetValueAsync(_email);

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
        
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("sid").SetValueAsync(_ID);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("SID updated");
        }
    }

    public IEnumerator LoadUserData()
    {
        
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

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
} 