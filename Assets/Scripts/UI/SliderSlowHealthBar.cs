using System.Collections;
using UnityEngine;

public class SliderSlowHealthBar : SliderHealthBar
{
    [SerializeField] private float _speed;

    private Coroutine _slowChangeCoroutine;

    public override void OnChanged(float change, float percentValue)
    {
        if (_slowChangeCoroutine != null)
            StopCoroutine(_slowChangeCoroutine);

        _slowChangeCoroutine = StartCoroutine(SlowChangeValue(percentValue));
    }

    private IEnumerator SlowChangeValue(float targetValue)
    {
        const float TargetTime = 1;

        float startValue = Slider.value;
        float time = 0;

        while (time < TargetTime)
        {
            time += _speed * Time.deltaTime;
            Slider.value = Mathf.Lerp(startValue, targetValue, time);

            yield return null;
        }
    }
}