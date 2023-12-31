using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to Change")]
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the Item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemCountText.text = "" + thisItem.numberHeld;
        }
    }

    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetupDescAndButton(thisItem.itemDesc, thisItem.usable, thisItem);
        }
    }
}
