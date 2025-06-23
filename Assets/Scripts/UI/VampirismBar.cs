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
        _vampirism.ChangedState += Change;
    }

    private void OnDisable()
    {
        _vampirism.ChangedState -= Change;
    }

    private void Change(float targetTime, float targetPercent)
    {
        if (_changeCoroutine != null)
            StopCoroutine(_changeCoroutine);

        _changeCoroutine = StartCoroutine(SlowChangeValue(targetTime, targetPercent));
    }

    private IEnumerator SlowChangeValue(float changeTime, float targetPercent)
    {
        float targetTime = 1;

        float startValue = _slider.value;
        float time = 0;

        while (time < targetTime)
        {
            time += Time.deltaTime / changeTime;
            _slider.value = Mathf.Lerp(startValue, targetPercent, time);

            yield return null;
        }
    }
}