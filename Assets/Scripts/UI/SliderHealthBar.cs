using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] protected Slider Slider;

    private Quaternion _lookDirection;

    private void Start()
    {
        Slider.interactable = false;
        Slider.minValue = 0;
        Slider.maxValue = 1;
        Slider.value = Health.Count / Health.Max;
        _lookDirection = Camera.main.transform.rotation;
    }

    private void Update()
    {
        transform.rotation = _lookDirection;
    }

    public override void OnChanged(float change, float percentValue)
    {
        Slider.value = percentValue;
    }
}