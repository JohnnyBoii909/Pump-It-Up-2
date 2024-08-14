using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class HighpassAudioFilter : MonoBehaviour
{
    private GameObject audioSourceOrigin;
    private HighpassAudioFilter highPassAudioFilter;
    private LowpassAudioFilter lowPassAudioFilter;

    private void Start()
    {
        audioSourceOrigin = FindObjectOfType<AudioSource>().gameObject;
        highPassAudioFilter = audioSourceOrigin.GetComponent<HighpassAudioFilter>();
        lowPassAudioFilter = audioSourceOrigin.GetComponent<LowpassAudioFilter>();
    }

    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            highPassAudioFilter.enabled = true;
            lowPassAudioFilter.enabled = false;
            //ApplyHighPassFilter();
            //DisableLowPassFilter();
        }
    }

    void ApplyHighPassFilter()
    {
        if (highPassAudioFilter != null)
        {
            if (highPassAudioFilter.enabled == false)
            {
                
            }
        }
    }

    void DisableLowPassFilter()
    {
        if (lowPassAudioFilter != null)
        {
            if (lowPassAudioFilter.enabled)
            {
                
            }
        }
    }
}
