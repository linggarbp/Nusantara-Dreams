using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Checkpoint
{
    public PlayerMovement PlayerMovement;
    [SerializeField]
    List<GameObject> playerHealth = new List<GameObject>();
    [SerializeField]
    GameObject retryPanel;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        retryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerMovement.playerHealth;
        //Debug.Log(health);
        if (health > 0)
        {
            for (int i = 0; i < playerHealth.Count; i++)
            {
                // Deactivate GameObjects from index 0 to (health - 1)
                playerHealth[i].SetActive(i < health);
            }
        }
        if (health == 0)
        {
            retryPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RespawnPlayer()
    {
        PlayerMovement.RespawnPlayer();
        PlayerMovement.playerHealth = 5;
        retryPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
