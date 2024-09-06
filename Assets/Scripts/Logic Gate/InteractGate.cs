using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGate : MonoBehaviour
{
    [Header("Visual & Trigger")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject bound;

    [SerializeField]
    private SwapGate switchGate;
    private bool playerInRange;

    private void Awake()
    {
        //switchGate = GetComponent<SwapGate>();
        playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (switchGate.gateListOR || switchGate.gateListAND)
                {
                    switchGate.GateORAND();
                }
                if (switchGate.gateListNOR || switchGate.gateListNAND)
                {
                    switchGate.GateNORNAND();
                }
                if (switchGate.gateListXOR || switchGate.gateListXNOR)
                {
                    switchGate.GateXORXNOR();
                }
                bound.SetActive(false);
            }
        }
        else
        {
            visualCue.SetActive(false);
            bound.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerInRange = false;
    }
}
