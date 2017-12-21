using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelishMeter : MonoBehaviour
{

    private Image content;

    private float lerpSpeed = 1;

    private float currentFill;

    public float MyMaxValue { get; set; }

    public float MyCurrentValue
    {

        get
        {
            return currentValue;
        }

        set
        {

            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
        }
    }

    private float currentValue;

    // Use this for initialization
    void Start()
    {
        content = GetComponent<Image>();

    }
    // Update is called once per frame
    void Update()
    {

        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

        content.fillAmount = currentFill;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
