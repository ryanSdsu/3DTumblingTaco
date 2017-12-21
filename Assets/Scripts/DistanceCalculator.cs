using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DistanceCalculator : MonoBehaviour {

    public float floor;
    public float currentPosition;
    public float meterPos;

    public Text distanceRemaining;

	// Use this for initialization
	void Start () {
        floor = -1790.999f;
        distanceRemaining.text = Math.Abs(floor).ToString();
        currentPosition = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        currentPosition = transform.position.y;
        meterPos = Math.Abs(floor) + currentPosition;
        distanceRemaining.text = meterPos.ToString();
	}
}
