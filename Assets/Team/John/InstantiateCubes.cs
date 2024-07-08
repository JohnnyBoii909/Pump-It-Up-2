using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;

    private GameObject[] _sampleCube;

    public int numberOfSamlpes;

    public float maxScale;
    
    // Start is called before the first frame update
    void Start()
    {
        _sampleCube = new GameObject[numberOfSamlpes];
        for (int i = 0; i < numberOfSamlpes; i++)
        {
            GameObject _instanceSampleCube = Instantiate(sampleCubePrefab);
            _instanceSampleCube.transform.position = transform.position;
            _instanceSampleCube.transform.parent = transform;
            _instanceSampleCube.name = "SampleCube" + i;
            transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = (Vector3.forward * 100) + new Vector3(0,20,0);
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(1,(AudioPeer.samples[i]*maxScale)*2, 1);
            }
        }
    }
}
