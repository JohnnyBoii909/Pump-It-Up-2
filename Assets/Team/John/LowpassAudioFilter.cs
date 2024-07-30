using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowpassAudioFilter : MonoBehaviour
{
    void ApplyLowPassFilter()
    {
        AudioLowPassFilter lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 1000.0f;
    }
}
