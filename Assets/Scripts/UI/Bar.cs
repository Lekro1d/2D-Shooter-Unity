using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Gradient _gradient;
    [SerializeField] protected Image _fill;

    public void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
