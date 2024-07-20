using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FMODEvents
{
    [SerializeField] private EventReferencesSO _references;

    /// <summary>
    /// Returns path of event as a string given its name (according to the EventReferences ScriptableObject)
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string GetEventReference(string name)
    {
        return _references.Events.Find(x => x.Name == name).EventReference;
    }
}
