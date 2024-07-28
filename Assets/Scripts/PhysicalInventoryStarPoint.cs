using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryStarPoint : MonoBehaviour
{
    [SerializeField] StarPointInventory starPointInventory;
    [SerializeField] StarPoint starPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Star"))
        {
            AddStarToBag();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Point"))
        {
            AddPointToBag();
            Destroy(this.gameObject);
        }
    }

    void AddStarToBag()
    {
        if (starPointInventory.starPoints.Contains(starPoint))
        {
            starPoint.numberHeld += 1;
        }
        else
        {
            starPointInventory.starPoints.Add(starPoint);
            starPoint.numberHeld += 1;
        }

    }

    void AddPointToBag()
    {

        if (starPointInventory.starPoints.Contains(starPoint))
        {
            starPoint.numberHeld += 100;
        }
        else
        {
            starPointInventory.starPoints.Add(starPoint);
            starPoint.numberHeld += 100;
        }

    }
}
