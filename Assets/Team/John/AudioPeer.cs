using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    public AudioSource _audioSource;
    public int numberOfSamples;
    public int numberOfBands;
    public float[] samples;
    public float[] freqBand;

    private void Awake()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
        samples = new float[numberOfSamples];
        freqBand = new float[numberOfBands];
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050 / 512 = 43hertz per sample
         *
         * 0-20hertz
         * 20-60hertz
         * 60-250hertz
         * 250-500hertz
         * 500-2000hertz
         * 2000-4000hertz
         * 4000-6000hertz
         * 6000-20000hertz
         *
         * 8 Bands
         *
         * 0 - 2 samples = 86hertz
         * 1 - 4 samples = 172hertz, Adding the last Hertz to this hertz gives us a range of 87-258 hertz
         * 2 - 8 samples = 344hertz, range = 259-602 hertz, As we go we are adding the hertz of all previous tiers
         * 3 - 16 samples = 688Hertz, range = 345-1290 hertz
         * 4 - 32 samples = 1378hertz, range = 1291-2666 hertz
         * 5 - 64 samples = 2752hertz, range = 2667-5418 hertz
         * 6 - 128 samples = 5504hertz, range = 5419-10922 hertz
         * 7 - 256 samples = 11008hertz, range = 10923-21930 hertz
         * 510 add 2 more and we will have our desired 512 channels
         */
        
        //This loops through and powers all the samples by 2 to set up
        int count = 0;
        
        for (int i = 0; i < numberOfBands; i++)
        {
            float average = 0;
            int sampleCount = (int) Mathf.Pow(2, i) * 2;

            if (i == numberOfBands-1)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count]*(count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
        
    }
    
    public float[] GetFrequencyBands()
    {
        return freqBand;
    }
}
