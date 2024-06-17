﻿using UnityEngine;

public class NOTGate : Gate
{
    public NOTGate(bool state) : base(state) { }

    public override void Interact()
    {
        if(inputGates.Count > 1)
        {
            Debug.LogError("'Not Gates' cannot have more than 1 input gate");
            return;
        }

        if (!inputGates[0].ActiveState)
            Enable();
        else
            Disable();
    }
}
