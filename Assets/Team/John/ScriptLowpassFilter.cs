using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(ScriptHighPassFilter))]
public class ScriptLowpassFilter : MonoBehaviour
{
    private GameObject _audioSourceOrigin;
    private AudioHighPassFilter _highPassAudioFilter;
    private AudioLowPassFilter _lowPassAudioFilter;
    private AudioReverbFilter _reverbFilter;
    
    private void Start()
    {
        _audioSourceOrigin = FindObjectOfType<AudioSource>().gameObject;
        _highPassAudioFilter = _audioSourceOrigin.GetComponent<AudioHighPassFilter>();
        _lowPassAudioFilter = _audioSourceOrigin.GetComponent<AudioLowPassFilter>();
        _reverbFilter = GetComponent<AudioReverbFilter>();
    }
    
    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            ApplyLowPassFilter();
            DisableHighPassFilter();
        }

        if(OVRInput.GetDown(OVRInput.Button.Two))
        {
            ResetAllFilters();
        }
    }
    
    void ApplyLowPassFilter()
    {
        if (_lowPassAudioFilter != null)
        {
            if (_lowPassAudioFilter.enabled == false)
            {
                _lowPassAudioFilter.enabled = true;
            }
        }
    }

    void DisableHighPassFilter()
    {
        if (_highPassAudioFilter != null)
        {
            if (_highPassAudioFilter.enabled)
            {
                _highPassAudioFilter.enabled = false;
            }
        }
    }

    void ResetAllFilters()
    {
        if(_lowPassAudioFilter.enabled)
        {
            _lowPassAudioFilter.enabled = false;
        }

        if (_highPassAudioFilter.enabled)
        {
            _highPassAudioFilter.enabled = false;
        }

        if (_reverbFilter.enabled)
        {
            _reverbFilter.enabled = false;
        }
    }
}
