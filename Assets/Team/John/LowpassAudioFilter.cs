using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class LowpassAudioFilter : MonoBehaviour
{
    private IVRDevice device;
    private IVRInputDevice rightHand;
    private GameObject audioSourceOrigin;
    private HighpassAudioFilter highPassFilter;
    private LowpassAudioFilter lowpassAudioFilter;
    
    private void Start()
    {
        device = VRDevice.Device;
        rightHand = device.SecondaryInputDevice;
        audioSourceOrigin = FindObjectOfType<AudioSource>().gameObject;
        highPassFilter = audioSourceOrigin.GetComponent<HighpassAudioFilter>();
        lowpassAudioFilter = audioSourceOrigin.GetComponent<LowpassAudioFilter>();
    }
    
    private void FixedUpdate()
    {
        if (rightHand != null)
        {
            if (rightHand.GetButtonDown(VRButton.Trigger))
            {
                ApplyLowPassFilter();
                DisableHighPassFilter();
            }

            if (rightHand.GetButtonDown(VRButton.Two))
            {
                ResetAllFilters();
            }
        }
    }
    
    void ApplyLowPassFilter()
    {
        if (lowpassAudioFilter != null)
        {
            if (lowpassAudioFilter.enabled == false)
            {
                lowpassAudioFilter.enabled = true;
            }
        }
    }

    void DisableHighPassFilter()
    {
        if (highPassFilter != null)
        {
            if (highPassFilter.enabled)
            {
                highPassFilter.enabled = false;
            }
        }
    }

    void ResetAllFilters()
    {
        if(lowpassAudioFilter.enabled)
        {
            lowpassAudioFilter.enabled = false;
        }

        if (highPassFilter.enabled)
        {
            highPassFilter.enabled = false;
        }
    }
}
