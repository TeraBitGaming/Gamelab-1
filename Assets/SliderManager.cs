using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    private Slider slider;
    private int currentValue = 50;
    private int highestValue = 100;

    //Function to set the current value of the slider to any specified amount.
    public void setCurrentValue(int value){
        currentValue = (int)Mathf.Clamp(value, 0, Mathf.Infinity);
    }

    //Function to set the maximum value of the slider to any specified amount. (not useful, I know but I can't be f*cked.)
    public void setHighestValue(int value){
        highestValue = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        Debug.Log((float)currentValue / (float)highestValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue > highestValue){
            highestValue = currentValue;
        } else if (highestValue > currentValue || currentValue == highestValue){
            slider.value = (float)currentValue / (float)highestValue;
        }
    }
}
