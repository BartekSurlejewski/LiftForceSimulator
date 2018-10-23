using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
	public TextMeshProUGUI sliderValueText;
    public DoubleVariable SliderValue;
    public double SliderValueAccesor
    {
        set { SliderValue.Value = value; }
    }
	public int decimalPlaces;
	public string suffix;

	private Slider slider;
	void Start()
	{
		slider = GetComponentInChildren<Slider>();
	}

    void Update()
    {
        sliderValueText.text = slider.value.ToString(BuildDecimalPattern()) + " " + suffix;
    }

	string BuildDecimalPattern()
	{
		return "0." + new String('0', decimalPlaces);
	}
}
