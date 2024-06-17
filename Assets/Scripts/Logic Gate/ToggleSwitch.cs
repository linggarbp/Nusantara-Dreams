using System.Collections;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    private Switch switchToToggle;

    private void Awake()
    {
        switchToToggle = GetComponent<Switch>();
    }

    private void Start()
    {

    }

    public void ToggleClick()
    {
        switchToToggle.Interact();
    }
}
