using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismBar : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Slider _slider;

    private Coroutine _changeCoroutine;

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = 1;
        _slider.value = 1;
        _slider.interactable = false;
    }

    private void OnEnable()
    {
        _vampirism.ChangedStatusVampirism += Change;
    }

    private void OnDisable()
    {
        _vampirism.ChangedStatusVampirism -= Change;
    }

    private void Change(float targetTime, float startValue, float targetValue)
    {
        if (_changeCoroutine != null)
            StopCoroutine(_changeCoroutine);

        _changeCoroutine = StartCoroutine(SlowChangeValue(targetTime, startValue, targetValue));
    }

    private IEnumerator SlowChangeValue(float changeTime, float startValue, float targetValue)
    {
        float time = 0;
        float targetTime = 1;

        while (time < targetTime)
        {
            time += Time.deltaTime / changeTime;
            _slider.value = Mathf.Lerp(startValue, targetValue, time);

            yield return null;
        }
    }
}