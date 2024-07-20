using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event References List", menuName = "Event References")]
public class EventReferencesSO : ScriptableObject
{
    public List<NamedEventReference> Events;
}

[Serializable]
public class NamedEventReference
{
    public string Name;
    [EventRef]
    public string EventReference;
}
