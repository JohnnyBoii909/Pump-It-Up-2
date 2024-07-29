using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumDataConsumer : MonoBehaviour
{ 
        public AudioPeer audioPeer;
        public Transform targetTransform;
        public int frequencyBandForScaling = 0;
        public int frequencyBandForRotation = 0;
        public float scaleMultiplier;
        public float rotationMultiplier;
        public Rigidbody rb;
        

        public float clock;

        private void Start()
        {
            StartCoroutine(TransformChangesCoroutine());
        }

        void ApplyTransformScalingBasedOnSpectrum(float intensity)
        {
            // Apply scaling
            float scale = 1 + intensity * scaleMultiplier;
            targetTransform.localScale = new Vector3(scale, scale, 0.2f);
        }

        void ApplyTransformRotationBasedOnSpectrumData(float intensity)
        {
            // Apply rotation
            float rotation = intensity * rotationMultiplier;
            targetTransform.Rotate(Vector3.forward, rotation * Time.deltaTime);
        }

        IEnumerator TransformChangesCoroutine()
        {
            while (true)
            {
                if (audioPeer != null)
                {
                    float[] frequencyBands = audioPeer.GetFrequencyBands();
                    if (frequencyBands != null && frequencyBands.Length > frequencyBandForScaling)
                    {
                        ApplyTransformScalingBasedOnSpectrum(frequencyBands[frequencyBandForScaling]);
                    }

                    if (frequencyBands != null && frequencyBands.Length > frequencyBandForRotation)
                    {
                        ApplyTransformRotationBasedOnSpectrumData(frequencyBands[frequencyBandForRotation]);
                    }
                    AddForceMoveForward();
                }

                yield return new WaitForSeconds(clock);
            }
        }

        void AddForceMoveForward()
        {
            rb.AddForce(new Vector3(0,0,-1),ForceMode.Acceleration);
        }
}
