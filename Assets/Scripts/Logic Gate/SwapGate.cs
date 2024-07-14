using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGate : Gate
{
    public PlayerInventory playerInventory;

    bool ORGate = false;
    bool ANDGate = false;
    bool NORGate = false;
    bool NANDGate = false;
    bool XORGate = false;
    bool XNORGate = false;

    private int gateOneORAND;
    private int gateOneNORNAND;
    private int gateOneXORXNOR;
    private int gateTwoORAND;
    private int gateTwoNORNAND;
    private int gateTwoXORXNOR;
    private int gateThreeORAND;
    private int gateThreeNORNAND;
    private int gateThreeXORXNOR;

    [SerializeField]
    List<GameObject> gateListOR = new List<GameObject>();
    [SerializeField]
    List<GameObject> gateListAND = new List<GameObject>();
    [SerializeField]
    List<GameObject> gateListNOR = new List<GameObject>();
    [SerializeField]
    List<GameObject> gateListNAND = new List<GameObject>();
    [SerializeField]
    List<GameObject> gateListXOR = new List<GameObject>();
    [SerializeField]
    List<GameObject> gateListXNOR = new List<GameObject>();

    private void Awake()
    {
        ORGate = true;
    }

    public SwapGate(bool state) : base(state) { }

    public override void Interact()
    {
        if (gateOneORAND == 1 || gateTwoORAND == 1 || gateThreeORAND == 1)
        {
            //OR Gate
            gateListOR[0].SetActive(true);
            gateListAND[0].SetActive(false);
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
        else if (gateOneORAND == 2 || gateTwoORAND == 2 || gateThreeORAND == 2)
        {
            //AND Gate
            gateListAND[0].SetActive(true);
            gateListOR[0].SetActive(false);
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
        else if (gateOneNORNAND == 1 || gateTwoNORNAND == 1 || gateThreeNORNAND == 1)
        {
            gateListNOR[0].SetActive(true);
            gateListNAND[0].SetActive(false);
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
        else if (gateOneNORNAND == 2 || gateTwoNORNAND == 2 || gateThreeNORNAND == 2)
        {
            gateListNAND[0].SetActive(true);
            gateListNOR[0].SetActive(false);
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
        else if (gateOneXORXNOR == 1 || gateTwoXORXNOR == 1 || gateThreeXORXNOR == 1)
        {
            gateListXOR[0].SetActive(true);
            gateListXNOR[0].SetActive(false);
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
        else if (gateOneXORXNOR == 2 || gateTwoXORXNOR == 2 || gateThreeXORXNOR == 2)
        {
            gateListXNOR[0].SetActive(true);
            gateListXOR[0].SetActive(false);
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
        if (ORGate == true && (gateOneORAND == 1 || gateTwoORAND == 1 || gateThreeORAND == 1))
        {
            Interact();
        }
        else if (ANDGate == true && (gateOneORAND == 2 || gateTwoORAND == 2 || gateThreeORAND == 2))
        {
            Interact();
        }
        else if (NORGate == true && (gateOneNORNAND == 1 || gateTwoNORNAND == 1 || gateThreeNORNAND == 1))
        {
            Interact();
        }
        else if (NANDGate == true && (gateOneNORNAND == 2 || gateTwoNORNAND == 2 || gateThreeNORNAND == 2))
        {
            Interact();
        }
        else if (XORGate == true && (gateOneXORXNOR == 1 || gateTwoXORXNOR == 1 || gateThreeXORXNOR == 1))
        {
            Interact();
        }
        else if (XNORGate == true && (gateOneXORXNOR == 2 || gateTwoXORXNOR == 2 || gateThreeXORXNOR == 2))
        {
            Interact();
        }
    }

    void IsItemExist()
    {
        //if (playerInventory.InventoryItems[0].numberHeld == 1)
        //{
        //    ORGate = true;
        //}
        if (playerInventory.InventoryItems[0].numberHeld == 1)
        {
            ANDGate = true;
        }
        else if (playerInventory.InventoryItems[1].numberHeld == 1)
        {
            NORGate = true;
        }
        else if (playerInventory.InventoryItems[2].numberHeld == 1)
        {
            NANDGate = true;
        }
        else if (playerInventory.InventoryItems[3].numberHeld == 1)
        {
            XORGate = true;
        }
        else if (playerInventory.InventoryItems[4].numberHeld == 1)
        {
            XNORGate = true;
        }
    }

    private int GetORANDItem()
    {
        return /*playerInventory.InventoryItems[0].numberHeld */1 + playerInventory.InventoryItems[0].numberHeld;
    }

    private int GetNORNANDItem()
    {
        return playerInventory.InventoryItems[2].numberHeld + playerInventory.InventoryItems[3].numberHeld;
    }

    private int GetXORXNORItem()
    {
        return playerInventory.InventoryItems[4].numberHeld + playerInventory.InventoryItems[5].numberHeld;
    }

    public void GateOneORAND()
    {
        gateOneORAND++;
        Swap();
        if (gateOneORAND > GetORANDItem())
        {
            gateOneORAND = 1;
            //gateListOR[0].SetActive(false);
            //gateListAND[0].SetActive(false);
        }
        Swap();
    }
    public void GateTwoORAND()
    {
        gateTwoORAND++;
        Swap();
        if (gateTwoORAND > GetORANDItem())
        {
            gateTwoORAND = 1;
            //gateListOR[0].SetActive(false);
            //gateListAND[0].SetActive(false);
        }
        Swap();
    }
    public void GateThreeORAND()
    {
        gateThreeORAND++;
        Swap();
        if (gateThreeORAND > GetORANDItem())
        {
            gateThreeORAND = 1;
            //gateListOR[0].SetActive(false);
            //gateListAND[0].SetActive(false);
        }
        Swap();
    }
    public void GateOneNORNAND()
    {
        gateOneNORNAND++;
        Swap();
        if (gateOneNORNAND > GetNORNANDItem())
        {
            gateOneNORNAND = 0;
            gateListNOR[0].SetActive(false);
            gateListNAND[0].SetActive(false);
        }
    }
    public void GateTwoNORNAND()
    {
        gateTwoNORNAND++;
        Swap();
        if (gateTwoNORNAND > GetNORNANDItem())
        {
            gateTwoNORNAND = 0;
            gateListNOR[0].SetActive(false);
            gateListNAND[0].SetActive(false);
        }
    }
    public void GateThreeNORNAND()
    {
        gateThreeNORNAND++;
        Swap();
        if (gateThreeNORNAND > GetNORNANDItem())
        {
            gateThreeNORNAND = 0;
            gateListNOR[0].SetActive(false);
            gateListNAND[0].SetActive(false);
        }
    }

    public void GateOneXORXNOR()
    {
        gateOneXORXNOR++;
        Swap();
        if (gateOneXORXNOR > GetXORXNORItem())
        {
            gateOneXORXNOR = 0;
            gateListXOR[0].SetActive(false);
            gateListXNOR[0].SetActive(false);
        }
    }
    public void GateTwoXORXNOR()
    {
        gateTwoXORXNOR++;
        Swap();
        if (gateTwoXORXNOR > GetXORXNORItem())
        {
            gateTwoXORXNOR = 0;
            gateListXOR[0].SetActive(false);
            gateListXNOR[0].SetActive(false);
        }
    }

    public void GateThreeXORXNOR()
    {
        gateThreeXORXNOR++;
        Swap();
        if (gateThreeXORXNOR > GetXORXNORItem())
        {
            gateThreeXORXNOR = 0;
            gateListXOR[0].SetActive(false);
            gateListXNOR[0].SetActive(false);
        }
    }

}
