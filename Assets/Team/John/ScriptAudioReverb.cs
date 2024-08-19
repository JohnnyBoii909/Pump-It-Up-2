using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptAudioReverb : MonoBehaviour
{
    public AudioReverbFilter reverbFilter;

    private void Start()
    {
        if (reverbFilter == null)
        {
            Debug.LogError("AudioReverbFilter is not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Debug.Log("OVRInput Button Four pressed");
            EnableDisableReverbFilter();
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S key pressed");
            EnableDisableReverbFilter();
        }
    }

    void EnableDisableReverbFilter()
    {
        if (reverbFilter != null)
        {
            reverbFilter.enabled = !reverbFilter.enabled;
            Debug.Log("Reverb filter enabled: " + reverbFilter.enabled);
        }
        else
        {
            Debug.LogError("AudioReverbFilter is null!");
        }
    }
}
