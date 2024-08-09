using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Serialization;

public class SpectrumDataConsumer : MonoBehaviour
{ 
        public AudioPeer audioPeer;
        public Transform targetTransform;
        public int frequencyBandForScaling = 0;
        public int frequencyBandForRotation = 0;
        public float scaleMultiplier;
        public float rotationMultiplier;
        public Rigidbody rb;
        public bool enableIfNotSpinnerCube;
        public Vector3 originalStartingSize;
        

        public float clock;

        private void Start()
        {
            if (enableIfNotSpinnerCube)
            {
                originalStartingSize = transform.localScale;
            }
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

        IEnumerator ApplyTransformScalingIfNotSpinnerCube(float intensity)
        {
            float scale = 1 + intensity * scaleMultiplier;
            var position = transform.localScale;
            targetTransform.localScale = new Vector3(scale+position.x, scale+position.y, scale+position.z);
            yield return new WaitForSeconds(clock);
            targetTransform.localScale = originalStartingSize;
        }

        IEnumerator TransformChangesCoroutine()
        {
            while (true)
            {
                if (audioPeer != null)
                {
                    float[] frequencyBands = audioPeer.GetFrequencyBands();
                    if (frequencyBands != null && frequencyBands.Length > frequencyBandForScaling && !enableIfNotSpinnerCube)
                    {
                        ApplyTransformScalingBasedOnSpectrum(frequencyBands[frequencyBandForScaling]);
                    }

                    if (frequencyBands != null && frequencyBands.Length > frequencyBandForRotation && !enableIfNotSpinnerCube)
                    {
                        ApplyTransformRotationBasedOnSpectrumData(frequencyBands[frequencyBandForRotation]);
                    }

                    if (!enableIfNotSpinnerCube)
                    {
                        AddForceMoveForward();
                    }

                    if (enableIfNotSpinnerCube)
                    {
                        if (frequencyBands != null && frequencyBands.Length > frequencyBandForScaling)
                        {
                            StartCoroutine(
                                ApplyTransformScalingIfNotSpinnerCube(frequencyBands[frequencyBandForScaling]));
                        }
                    }
                }

                yield return new WaitForSeconds(clock);
            }
        }

        

        void AddForceMoveForward()
        {
            rb.AddForce(new Vector3(0,0,-1),ForceMode.Force);
        }
}
