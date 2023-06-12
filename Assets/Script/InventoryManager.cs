using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInvetorySlot;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    public void SetTextAndButton(string desc, bool buttonActive)
    {
        descText.text = desc;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for (int i = 0; i < playerInventory.InventoryItems.Count; i++)
            {
                if (playerInventory.InventoryItems[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInvetorySlot, contentPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(contentPanel.transform, false);
                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.InventoryItems[i], this);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    public void SetupDescAndButton(string desc, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descText.text = desc;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for (int i = 0; i < contentPanel.transform.childCount; i++)
        {
            Destroy(contentPanel.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();

            ClearInventorySlots();

            MakeInventorySlots();

            if (currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
}
