using System.Collections;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    private Switch switchToToggle;

    private void Awake()
    {
        switchToToggle = GetComponent<Switch>();
    }

    public void ToggleClick()
    {
        switchToToggle.Interact();
    }
}
