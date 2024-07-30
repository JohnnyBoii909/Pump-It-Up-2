using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighpassAudioFilter : MonoBehaviour
{
    void ApplyLowPassFilter()
    {
        AudioHighPassFilter highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = 500.0f; 
    }
}
