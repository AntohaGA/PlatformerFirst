using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : HealthBar
{
    [SerializeField] protected Slider Slider;

    private Camera _camera;

    private void Start()
    {
        Slider.interactable = false;
        Slider.minValue = 0;
        Slider.maxValue = 1;
        Debug.Log("Awake ----" + "Health.Count - " + Health.Count + "Health.Max - " + Health.Max);
        Slider.value = Health.Count / Health.Max;
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }

    public override void OnChanged(float change, float maxValue)
    {
        Slider.value = (Slider.value + change) / maxValue;
    }
}