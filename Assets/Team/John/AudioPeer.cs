using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    public AudioSource _audioSource;
    public float[] samples = new float[512];
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();

        if (Input.GetKeyDown("s"))
        {
            PlayAudio();
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void PlayAudio()
    {
        _audioSource.Play();
    }
}
