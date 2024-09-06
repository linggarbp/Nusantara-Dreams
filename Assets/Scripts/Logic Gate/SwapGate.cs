using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGate : Gate
{
    public PlayerInventory playerInventory;
    public DebriefingCount swapCount;

    bool ORGate = false;
    bool ANDGate = false;
    bool NORGate = false;
    bool NANDGate = false;
    bool XORGate = false;
    bool XNORGate = false;

    private int gateORAND;
    private int gateNORNAND;
    private int gateXORXNOR;

    public GameObject gateListOR;
    public GameObject gateListAND;
    public GameObject gateListNOR;
    public GameObject gateListNAND;
    public GameObject gateListXOR;
    public GameObject gateListXNOR;

    private void Awake()
    {

    }

    public SwapGate(bool state) : base(state) { }

    public override void Interact()
    {
        if (ORGate == true && gateORAND == 1)
        {
            //OR Gate
            gateListOR.SetActive(true);
            gateListAND.SetActive(false);
            foreach (Gate gate in inputGates)
            {
                if (gate.ActiveState == true)
                {
                    Enable();
                    return;
                }
            }
            Disable();
        }
        else if (ANDGate == true && gateORAND == 2)
        {
            //AND Gate
            gateListAND.SetActive(true);
            gateListOR.SetActive(false);
            foreach (Gate gate in inputGates)
            {
                if (gate.ActiveState == false)
                {
                    Disable();
                    return;
                }
            }
            Enable();
        }
        //NOR Gate
        else if (NORGate == true && gateNORNAND == 1)
        {
            gateListNOR.SetActive(true);
            gateListNAND.SetActive(false);
            foreach (Gate gate in inputGates)
            {
                if (gate.ActiveState == true)
                {
                    Disable();
                    return;
                }
            }
            Enable();
        }
        //NAND Gate
        else if (NANDGate == true && gateNORNAND == 2)
        {
            gateListNAND.SetActive(true);
            gateListNOR.SetActive(false);
            foreach (Gate gate in inputGates)
            {
                if (gate.ActiveState == false)
                {
                    Enable();
                    return;
                }
            }
            Disable();
        }
        //XOR Gate
        else if (XORGate == true && gateXORXNOR == 1)
        {
            gateListXOR.SetActive(true);
            gateListXNOR.SetActive(false);
            bool initialInput = inputGates[0].ActiveState;
            for (int i = 1; i < inputGates.Count; i++)
            {
                if (inputGates[i].ActiveState != initialInput)
                {
                    Enable();
                    return;
                }
            }
            Disable();
        }
        //XNOR Gate
        else if (XNORGate == true && gateXORXNOR == 2)
        {
            gateListXNOR.SetActive(true);
            gateListXOR.SetActive(false);
            bool initialInput = inputGates[0].ActiveState;
            for (int i = 1; i < inputGates.Count; i++)
            {
                if (inputGates[i].ActiveState != initialInput)
                {
                    Disable();
                    return;
                }
            }
            Enable();
        }
    }

    //public void EnableRune()
    //{
    //    if (gateOneORAND == 1 || gateTwoORAND == 1 || gateThreeORAND == 1)
    //    {
    //        gateListOR[1].SetActive(true);
    //        gateListOR[2].SetActive(false);
    //    }
    //    else if (gateOneORAND == 2 || gateTwoORAND == 2 || gateThreeORAND == 2)
    //    {
    //        gateListAND[1].SetActive(true);
    //        gateListAND[2].SetActive(false);
    //    }
    //    else if (gateOneNORNAND == 1 || gateTwoNORNAND == 1 || gateThreeNORNAND == 1)
    //    {
    //        gateListOR[1].SetActive(true);
    //        gateListOR[2].SetActive(false);
    //    }
    //    else if (gateOneNORNAND == 2 || gateTwoNORNAND == 2 || gateThreeNORNAND == 2)
    //    {
    //        gateListAND[1].SetActive(true);
    //        gateListAND[2].SetActive(false);
    //    }
    //    else if (gateOneXORXNOR == 1 || gateTwoXORXNOR == 1 || gateThreeXORXNOR == 1)
    //    {
    //        gateListOR[1].SetActive(true);
    //        gateListOR[2].SetActive(false);
    //    }
    //    else if (gateOneXORXNOR == 2 || gateTwoXORXNOR == 2 || gateThreeXORXNOR == 2)
    //    {
    //        gateListAND[1].SetActive(true);
    //        gateListAND[2].SetActive(false);
    //    }
    //}

    //public void DisableRune()
    //{
    //    if (gateOneORAND == 1 || gateTwoORAND == 1 || gateThreeORAND == 1)
    //    {
    //        gateListOR[1].SetActive(false);
    //        gateListOR[2].SetActive(true);
    //    }
    //    else if (gateOneORAND == 2 || gateTwoORAND == 2 || gateThreeORAND == 2)
    //    {
    //        gateListAND[1].SetActive(false);
    //        gateListAND[2].SetActive(true);
    //    }
    //    else if (gateOneNORNAND == 1 || gateTwoNORNAND == 1 || gateThreeNORNAND == 1)
    //    {
    //        gateListOR[1].SetActive(false);
    //        gateListOR[2].SetActive(true);
    //    }
    //    else if (gateOneNORNAND == 2 || gateTwoNORNAND == 2 || gateThreeNORNAND == 2)
    //    {
    //        gateListAND[1].SetActive(false);
    //        gateListAND[2].SetActive(true);
    //    }
    //    else if (gateOneXORXNOR == 1 || gateTwoXORXNOR == 1 || gateThreeXORXNOR == 1)
    //    {
    //        gateListOR[1].SetActive(false);
    //        gateListOR[2].SetActive(true);
    //    }
    //    else if (gateOneXORXNOR == 2 || gateTwoXORXNOR == 2 || gateThreeXORXNOR == 2)
    //    {
    //        gateListAND[1].SetActive(false);
    //        gateListAND[2].SetActive(true);
    //    }
    //}

    public void Swap()
    {
        IsItemExist();
        if ((ORGate && gateORAND == 1) || (ANDGate && gateORAND == 2) || (NORGate && gateNORNAND == 1) || (NANDGate && gateNORNAND == 2) || (XORGate && gateXORXNOR == 1) || (XNORGate && gateXORXNOR == 2))
        {
            swapCount.swapGateCount++;
            Interact();
        }
    }

    void IsItemExist()
    {
        if (playerInventory.InventoryItems[0].numberHeld >= 1)
        {
            ORGate = true;
        }
        if (playerInventory.InventoryItems[1].numberHeld >= 1)
        {
            ANDGate = true;
        }
        if (playerInventory.InventoryItems[2].numberHeld >= 1)
        {
            NORGate = true;
        }
        if (playerInventory.InventoryItems[3].numberHeld >= 1)
        {
            NANDGate = true;
        }
        if (playerInventory.InventoryItems[4].numberHeld >= 1)
        {
            XORGate = true;
        }
        if (playerInventory.InventoryItems[5].numberHeld >= 1)
        {
            XNORGate = true;
        }
    }

    private int GetORANDItem()
    {
        return playerInventory.InventoryItems[0].numberHeld + playerInventory.InventoryItems[1].numberHeld;
    }

    private int GetNORNANDItem()
    {
        return playerInventory.InventoryItems[2].numberHeld + playerInventory.InventoryItems[3].numberHeld;
    }

    private int GetXORXNORItem()
    {
        return playerInventory.InventoryItems[4].numberHeld + playerInventory.InventoryItems[5].numberHeld;
    }

    public void GateORAND()
    {
        gateORAND++;
        Swap();
        if (gateORAND > GetORANDItem())
        {
            gateORAND = 1;
        }
        Swap();
    }

    public void GateNORNAND()
    {
        gateNORNAND++;
        Swap();
        if (gateNORNAND > GetNORNANDItem())
        {
            gateNORNAND = 1;
        }
        Swap();
    }

    public void GateXORXNOR()
    {
        gateXORXNOR++;
        Swap();
        if (gateXORXNOR > GetXORXNORItem())
        {
            gateXORXNOR = 1;
        }
        Swap();
    }
}
