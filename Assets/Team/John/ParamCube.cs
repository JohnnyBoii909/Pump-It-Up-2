﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeTransformScale();
    }

    private void ChangeTransformScale()
    {
        transform.localScale = new Vector3(transform.localScale.x,
            (AudioPeer._freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
    }

    void ChangeTransformRotation()
    {
        
    }
}
