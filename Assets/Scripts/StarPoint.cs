using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StarPoint", menuName = "Inventory/StarPoint")]
public class StarPoint : ScriptableObject
{
    public string itemName;
    public int numberHeld;
}
