using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bag", menuName = "Inventory/StarPointInventory")]
public class StarPointInventory : ScriptableObject
{
    public List<StarPoint> starPoints = new List<StarPoint>();
}
