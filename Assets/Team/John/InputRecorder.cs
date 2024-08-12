using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputRecorder : MonoBehaviour
{
    public Text displayText; // Assign in the Unity Inspector
    private List<string> inputLog = new List<string>();

    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                string inputString = key.ToString();
                inputLog.Insert(0, inputString); // Insert at the top of the list
                UpdateDisplay();
            }
        }
    }

    void UpdateDisplay()
    {
        displayText.text = string.Join("\n", inputLog.ToArray());
    }
}
