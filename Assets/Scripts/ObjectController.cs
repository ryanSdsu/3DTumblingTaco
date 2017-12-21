using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    Renderer objRenderer;
    public int scaleCount;
	// Use this for initialization
	void Start () {
        scaleCount = 0;
        DelegateHandler.buttonClickDelegate += scaleUp;
        objRenderer = GetComponent<Renderer>();
	}

    void scaleUp()
    {
        scaleCount++;

        if (scaleCount <= 3)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, transform.localScale.z * 1.25f);
        }
    }

    // Unsubscribe Delegate
    void OnDisable()
    {
        DelegateHandler.buttonClickDelegate -= scaleUp;
    }
}
