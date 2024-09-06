using System.Collections;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    private Switch switchToToggle;
    public DebriefingCount debriefingCount;

    private void Awake()
    {
        switchToToggle = GetComponent<Switch>();
    }

    public void ToggleClick()
    {
        debriefingCount.swapGateCount++;
        switchToToggle.Interact();
    }
}
