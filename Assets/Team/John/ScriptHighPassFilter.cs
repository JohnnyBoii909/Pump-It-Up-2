
using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptHighPassFilter : MonoBehaviour
{
    private GameObject _audioSourceOrigin;
    private AudioHighPassFilter _HighPassAudioFilter;
    private AudioLowPassFilter _LowPassAudioFilter;

    private void Start()
    {
        _audioSourceOrigin = FindObjectOfType<AudioSource>().gameObject;
        _HighPassAudioFilter = _audioSourceOrigin.GetComponent<AudioHighPassFilter>();
        _LowPassAudioFilter = _audioSourceOrigin.GetComponent<AudioLowPassFilter>();
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three))
        {
            ApplyHighPassFilter();
            DisableLowPassFilter();
        }
    }

    void ApplyHighPassFilter()
    {
        if (_HighPassAudioFilter != null)
        {
            if (_HighPassAudioFilter.enabled == false)
            {
                _HighPassAudioFilter.enabled = true;
            }
        }
    }

    void DisableLowPassFilter()
    {
        if (_LowPassAudioFilter != null)
        {
            if (_LowPassAudioFilter.enabled)
            {
                _LowPassAudioFilter.enabled = false;
            }
        }
    }
}
