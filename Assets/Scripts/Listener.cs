using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour {

    public GameObject EventManager; // reference to the firing obj
    public int test;

	// Use this for initialization
	void Start () {
        EventManager.GetComponent<DelegateHandler>().wasClicked += SomethingWasClickedOutside;
	}
	
	void SomethingWasClickedOutside()
    {
        Debug.Log("listener.cs: Event was fired!");
    }
}
