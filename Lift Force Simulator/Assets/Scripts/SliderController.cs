using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public TextMeshProUGUI sliderValueText;
    public DoubleVariable SliderValue;
    public int decimalPlaces;
    public string suffix;

    private Slider slider;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        UpdateSliderValue();
    }

    void Update()
    {
        sliderValueText.text = slider.value.ToString(BuildDecimalPattern()) + " " + suffix;
    }

    public void UpdateSliderValue()
    {
        SliderValue.Value = slider.value;
    }

    string BuildDecimalPattern()
    {
        return "0." + new String('0', decimalPlaces);
    }
}
