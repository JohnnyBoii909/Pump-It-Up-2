using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class LowpassAudioFilter : MonoBehaviour
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
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            lowPassAudioFilter.enabled = true;
            highPassAudioFilter.enabled = false;
            //ApplyLowPassFilter();
            //DisableHighPassFilter();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        { 
            highPassAudioFilter.enabled = false;
            lowPassAudioFilter.enabled = false;
            //ResetAllFilters();
        }
    }
    
    void ApplyLowPassFilter()
    {
        if (lowPassAudioFilter != null)
        {
            if (lowPassAudioFilter.enabled == false)
            {
                
            }
        }
    }

    void DisableHighPassFilter()
    {
        if (highPassAudioFilter != null)
        {
            if (highPassAudioFilter.enabled)
            {
                
            }
        }
    }

    void ResetAllFilters()
    {
        if(lowPassAudioFilter.enabled)
        {
            
        }

        if (highPassAudioFilter.enabled)
        {
            highPassAudioFilter.enabled = false;
        }
    }
}
