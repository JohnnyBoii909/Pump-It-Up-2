using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAudioReverb : MonoBehaviour
{
    private AudioReverbFilter _reverbFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        _reverbFilter = GetComponent<AudioReverbFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            EnableReverbFilter();
            DisableReverbFilter();
        }
    }

    void EnableReverbFilter()
    {
        if (_reverbFilter.enabled == false)
        {
            _reverbFilter.enabled = true;
        }
    }

    void DisableReverbFilter()
    {
        if (_reverbFilter.enabled == true)
        {
            _reverbFilter.enabled = false;
        }
    }
}
