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

    [HideInInspector] public int score;
    [HideInInspector] public int point;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text pointText;
    //private Enemy totalScore;

    void Start()
    {
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ingamePanel.SetActive(true);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "" + point;
        scoreText.text = "" + score;

        //Pause Game
        GamePause();

        //Open Inventory
        if (Input.GetKeyDown(KeyCode.Tab) && !isInventoryActivePanel && !isPauseActivePanel)
        {
            inventoryPanel.SetActive(true);
            isInventoryActivePanel = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isInventoryActivePanel)
        {
            inventoryPanel.SetActive(false);
            isInventoryActivePanel = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInventoryActivePanel && !isPauseActivePanel)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void GameResume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
