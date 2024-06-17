public class ORGate : Gate
{
    public ORGate(bool state) : base(state) { }

    public override void Interact()
    {
        foreach(Gate gate in inputGates)
        {
            if(gate.ActiveState == true)
            {
                Enable();
                return;
            }
        }
        Disable();
    }
}
