using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSwitch : MonoBehaviour
{
    [Header("Visual & Trigger")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject bound;

    private Switch switchToToggle;
    private bool playerInRange;

    private void Awake()
    {
        switchToToggle = GetComponent<Switch>();
        playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                switchToToggle.Interact();
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