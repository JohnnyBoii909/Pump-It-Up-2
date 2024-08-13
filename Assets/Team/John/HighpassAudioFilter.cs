using System;
using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class HighpassAudioFilter : MonoBehaviour
{
    private IVRDevice device;
    private IVRInputDevice leftHand;
    private GameObject audioSourceOrigin;
    private HighpassAudioFilter highPassFilter;
    private LowpassAudioFilter lowpassAudioFilter;

    private void Start()
    {
        device = VRDevice.Device;
        leftHand = device.PrimaryInputDevice;
        audioSourceOrigin = FindObjectOfType<AudioSource>().gameObject;
        highPassFilter = audioSourceOrigin.GetComponent<HighpassAudioFilter>();
        lowpassAudioFilter = audioSourceOrigin.GetComponent<LowpassAudioFilter>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown(KeyCode.Joystick1Button2.ToString()))
        {
            ApplyHighPassFilter();
            DisableLowPassFilter();
        }
    }

    void ApplyHighPassFilter()
    {
        if (highPassFilter != null)
        {
            if (highPassFilter.enabled == false)
            {
                highPassFilter.enabled = true;
            }
        }
    }

    void DisableLowPassFilter()
    {
        if (lowpassAudioFilter != null)
        {
            if (lowpassAudioFilter.enabled)
            {
                lowpassAudioFilter.enabled = false;
            }
        }
    }
}
