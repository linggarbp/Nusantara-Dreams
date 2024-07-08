using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq.Expressions;
using System;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to Change")]
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the Item")]
    public InventoryItem inventoryItem;
    public InventoryManager inventoryManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        inventoryItem = newItem;
        inventoryManager = newManager;
        if (inventoryItem)
        {
            itemImage.sprite = inventoryItem.itemImage;
            itemCountText.text = "" + inventoryItem.numberHeld;
        }
    }

    public void ClickedOn()
    {
        if (inventoryItem)
        {
            inventoryManager.SetupDescAndButton(inventoryItem.itemDesc, inventoryItem.usable, inventoryItem);
        }
    }
}
