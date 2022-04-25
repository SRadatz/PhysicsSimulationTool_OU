using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject m1e1PreviewImage;
    [SerializeField] GameObject m1e2PreviewImage;
    [SerializeField] GameObject m2e1PreviewImage;
    [SerializeField] GameObject m2e2PreviewImage;
    [SerializeField] GameObject m3e1PreviewImage;
    int currentImage;
    // Start is called before the first frame update
    void Start()
    {
        currentImage = 1;
        m1e1PreviewImage.SetActive(true);
        m1e2PreviewImage.SetActive(false);
        m2e1PreviewImage.SetActive(false);
        m2e2PreviewImage.SetActive(false);
        m3e1PreviewImage.SetActive(false);
        SlideShow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SlideShow()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        switch (currentImage)
        {
            case 1:
                m1e1PreviewImage.SetActive(false);
                m1e2PreviewImage.SetActive(true);
                m2e1PreviewImage.SetActive(false);
                m2e2PreviewImage.SetActive(false);
                m3e1PreviewImage.SetActive(false);
                currentImage = 2;
                break;
            case 2:
                m1e1PreviewImage.SetActive(false);
                m1e2PreviewImage.SetActive(false);
                m2e1PreviewImage.SetActive(true);
                m2e2PreviewImage.SetActive(false);
                m3e1PreviewImage.SetActive(false);
                currentImage = 3;
                break;
            case 3:
                m1e1PreviewImage.SetActive(false);
                m1e2PreviewImage.SetActive(false);
                m2e1PreviewImage.SetActive(false);
                m2e2PreviewImage.SetActive(true);
                m3e1PreviewImage.SetActive(false);
                currentImage = 4;
                break;
            case 4:
                m1e1PreviewImage.SetActive(false);
                m1e2PreviewImage.SetActive(false);
                m2e1PreviewImage.SetActive(false);
                m2e2PreviewImage.SetActive(false);
                m3e1PreviewImage.SetActive(true);
                currentImage = 5;
                break;
            case 5:
                m1e1PreviewImage.SetActive(true);
                m1e2PreviewImage.SetActive(false);
                m2e1PreviewImage.SetActive(false);
                m2e2PreviewImage.SetActive(false);
                m3e1PreviewImage.SetActive(false);
                currentImage = 1;
                break;


        }
        Debug.Log(currentImage);
        yield return new WaitForSecondsRealtime(3);
        SlideShow();

    }
}
