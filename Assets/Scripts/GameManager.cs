using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject ingamePanel;
    private bool isInventoryActivePanel = false;
    private bool isPauseActivePanel = false;
    //private Enemy totalScore;

    void Start()
    {
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        ingamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        //Pause Game
        GamePause();

        //Open Inventory
        if (Input.GetKeyDown(KeyCode.Tab) && !isInventoryActivePanel && !isPauseActivePanel)
        {
            inventoryPanel.SetActive(true);
            isInventoryActivePanel = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isInventoryActivePanel)
        {
            inventoryPanel.SetActive(false);
            isInventoryActivePanel = false;

        }
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInventoryActivePanel && !isPauseActivePanel)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void GameResume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
