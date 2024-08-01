using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFilterController : MonoBehaviour
{
    [SerializeField] private float _lowPassCutOffFrequency = 600f;
    [SerializeField] private float _highPassCutOffFrequency = 2500f;
    [Space]

    [SerializeField] private float _lerpDuration;

    private AudioLowPassFilter _lowPassFilter;
    private AudioHighPassFilter _highPassFilter;

    private enum FilterState { Off, LowPass, HighPass }
    private FilterState _filterState;

    private void Awake()
    {
        _lowPassFilter = GetComponent<AudioLowPassFilter>();
        _highPassFilter = GetComponent<AudioHighPassFilter>();

        _filterState = FilterState.Off;
    }

    public void ToggleLowPassFilter()
    {
        switch (_filterState)
        {
            case FilterState.Off:
                _filterState = FilterState.LowPass;
                StartCoroutine(LerpFilter(_lowPassFilter, true, _lowPassCutOffFrequency, _lerpDuration, null));
                break;

            case FilterState.LowPass:
                StartCoroutine(LerpFilter(_lowPassFilter, false, _lowPassCutOffFrequency, _lerpDuration, () => _filterState = FilterState.Off));
                break;

            case FilterState.HighPass:
                StartCoroutine(LerpFilter(_highPassFilter, false, _highPassCutOffFrequency, _lerpDuration, null));
                _filterState = FilterState.LowPass;
                StartCoroutine(LerpFilter(_lowPassFilter, true, _lowPassCutOffFrequency, _lerpDuration, null));
                break;

            default:
                break;
        }
    }

    public void ToggleHighPassFilter()
    {
        switch (_filterState)
        {
            case FilterState.Off:
                _filterState = FilterState.HighPass;
                StartCoroutine(LerpFilter(_highPassFilter, true, _highPassCutOffFrequency, _lerpDuration, null));
                break;

            case FilterState.LowPass:
                StartCoroutine(LerpFilter(_lowPassFilter, false, _lowPassCutOffFrequency, _lerpDuration, null));
                _filterState = FilterState.HighPass;
                StartCoroutine(LerpFilter(_highPassFilter, true, _highPassCutOffFrequency, _lerpDuration, null));
                break;

            case FilterState.HighPass:
                StartCoroutine(LerpFilter(_highPassFilter, false, _highPassCutOffFrequency, _lerpDuration, () => _filterState = FilterState.Off));
                break;

            default:
                break;
        }
    }

    private IEnumerator LerpFilter(AudioLowPassFilter filter, bool isActivating, float cutOffFrequency, float duration, Action callback)
    {
        StopAllCoroutines();

        float start, end, counter;
        start = filter.cutoffFrequency;
        if (isActivating)
        {
            end = cutOffFrequency;
        }
        else
        {
            end = 22000;
        }

        counter = 0f;
        while (counter <= duration)
        {
            filter.cutoffFrequency = Mathf.Lerp(start, end, counter / duration);
            counter += Time.deltaTime;
            yield return null;
        }

        filter.cutoffFrequency = end;
        callback?.Invoke();

        yield return null;
    }

    private IEnumerator LerpFilter(AudioHighPassFilter filter, bool isActivating, float cutOffFrequency, float duration, Action callback)
    {
        StopAllCoroutines();

        float start, end, counter;
        start = filter.cutoffFrequency;
        if (isActivating)
        {
            end = cutOffFrequency;
        }
        else
        {
            end = 10;
        }

        counter = 0f;
        while (counter < duration)
        {
            filter.cutoffFrequency = Mathf.Lerp(start, end, counter / duration);
            counter += Time.deltaTime;
            yield return null;
        }

        filter.cutoffFrequency = end;
        callback?.Invoke();

        yield return null;
    }

#if UNITY_EDITOR
    // Development testing
    private void Update()
    {
        // Toggle LPF
        if (Input.GetKeyDown(KeyCode.F11))
        {
            ToggleLowPassFilter();
        }
        // Toggle HPF
        else if (Input.GetKeyDown(KeyCode.F12))
        {
            ToggleHighPassFilter();
        }
    }
#endif
}
