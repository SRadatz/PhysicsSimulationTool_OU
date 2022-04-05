using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{

    //[SerializeField] private Image _img;
    //[SerializeField] private Sprite _default, _pressed;
    //[SerializeField] private AudioClip _compressClip, _uncompressClip;
    //[SerializeField] private AudioSource _source;

    public void OnPointerDown(PointerEventData eventDate)
    {
        // on press
        /*
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
        */
    }

    public void OnPointerUp(PointerEventData eventDate)
    {
        // on release
        /*
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
        */
    }

        public void TopicOneWasClicked()
    {
        Debug.Log("Go to topic one.");
    }

        public void TopicTwoWasClicked()
    {
        Debug.Log("Go to topic two.");
    }

        public void TopicThreeWasClicked()
    {
        Debug.Log("Go to topic three.");
    }

    public void LeftWasClicked()
    {
        Debug.Log("Left was clicked.");
    }

    public void RightWasClicked()
    {
        Debug.Log("Right was clicked.");
    }

        public void BackWasClicked()
    {
        Debug.Log("Back was clicked.");
    }

        public void HelpWasClicked()
    {
        Debug.Log("Right was clicked.");
    }

}
