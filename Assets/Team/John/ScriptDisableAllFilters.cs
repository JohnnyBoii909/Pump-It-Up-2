using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDisableAllFilters : MonoBehaviour
{
    public AudioHighPassFilter highPassAudioFilter;
    public AudioLowPassFilter lowPassAudioFilter;
    public AudioReverbFilter reverbFilter;

    void Start()
    {
        Debug.Log("ScriptDisableAllFilters started");
        CheckFilters();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log("OVRInput Button Two pressed");
            ResetAllFilters();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W key pressed");
            ResetAllFilters();
        }
    }

    private void ResetAllFilters()
    {
        Debug.Log("Attempting to reset all filters");
        
        if (lowPassAudioFilter != null)
        {
            lowPassAudioFilter.enabled = false;
            Debug.Log("Low Pass Filter disabled");
        }
        else
        {
            Debug.LogWarning("Low Pass Filter is null");
        }

        if (highPassAudioFilter != null)
        {
            highPassAudioFilter.enabled = false;
            Debug.Log("High Pass Filter disabled");
        }
        else
        {
            Debug.LogWarning("High Pass Filter is null");
        }

        if (reverbFilter != null)
        {
            reverbFilter.enabled = false;
            Debug.Log("Reverb Filter disabled");
        }
        else
        {
            Debug.LogWarning("Reverb Filter is null");
        }

        CheckFilters();
    }

    private void CheckFilters()
    {
        Debug.Log("Filter states: " +
                  "Low Pass: " + (lowPassAudioFilter ? lowPassAudioFilter.enabled.ToString() : "null") + ", " +
                  "High Pass: " + (highPassAudioFilter ? highPassAudioFilter.enabled.ToString() : "null") + ", " +
                  "Reverb: " + (reverbFilter ? reverbFilter.enabled.ToString() : "null"));
    }
}
