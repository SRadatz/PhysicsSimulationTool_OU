using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public SceneLoader loader;

    private void Awake()
    {
        StartCoroutine(WaitTime());
        SceneManager.LoadScene("ProfilePage");
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
    }
}
