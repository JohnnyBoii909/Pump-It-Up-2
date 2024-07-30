using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPodium : MonoBehaviour
{
    public GameObject podium;

    void TurnOffThePodiumView()
    {
        podium.SetActive(false);
    }
}
