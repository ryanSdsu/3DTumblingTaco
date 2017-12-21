using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour {

    public delegate void OnButtonClickDelegate();
    public static OnButtonClickDelegate buttonClickDelegate;

    public delegate void Clicked();
    public event Clicked wasClicked;

    public void OnButtonClick()
    {
        buttonClickDelegate();
    }

    void OnMouseDown()
    {
        if (wasClicked != null)
        {
            Debug.Log("We have a listener, send event");
            buttonClickDelegate();
            wasClicked();
        } else
        {
            Debug.Log("Nobody is listening!!! nooo");
        }
    }
}
