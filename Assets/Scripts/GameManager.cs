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
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject storyPanel;

    [HideInInspector] public int score;
    [HideInInspector] public int star;
    [HideInInspector] public int point;
    [SerializeField] TMP_Text starText;
    [SerializeField] TMP_Text pointText;
    public StarPointInventory StarPointInventory;
    public PlayerInventory PlayerInventory;
    public DebriefingCount debriefingCount;
    //private Enemy totalScore;

    private void Awake()
    {
        
    }

    void Start()
    {
        inventoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        questPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ingamePanel.SetActive(true);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        star = StarPointInventory.starPoints[0].numberHeld;
        point = StarPointInventory.starPoints[1].numberHeld;
        starText.text = "" + star;
        pointText.text = "" + point;

        //Pause Game
        GamePause();

        //Open Quest
        if (Input.GetKeyDown(KeyCode.Q) &&
            !inventoryPanel.activeSelf &&
            !pausePanel.activeSelf &&
            !questPanel.activeSelf &&
            !storyPanel.activeSelf)
        {
            questPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Q)
            && questPanel.activeSelf)
        {
            questPanel.SetActive(false);
        }

        //Open Inventory
        if (Input.GetKeyDown(KeyCode.Tab) &&
            !inventoryPanel.activeSelf &&
            !pausePanel.activeSelf &&
            !questPanel.activeSelf &&
            !storyPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) &&
            !inventoryPanel.activeSelf &&
            !pausePanel.activeSelf &&
            !questPanel.activeSelf &&
            !storyPanel.activeSelf)
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
        PlayerInventory.InventoryItems[0].numberHeld = 0;
        PlayerInventory.InventoryItems[1].numberHeld = 0;
        PlayerInventory.InventoryItems[2].numberHeld = 0;
        PlayerInventory.InventoryItems[3].numberHeld = 0;
        PlayerInventory.InventoryItems[4].numberHeld = 0;
        PlayerInventory.InventoryItems[5].numberHeld = 0;
        PlayerInventory.InventoryItems[6].numberHeld = 0;
        StarPointInventory.starPoints[0].numberHeld = 0;
        StarPointInventory.starPoints[1].numberHeld = 0;
        debriefingCount.swapGateCount = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        PlayerInventory.InventoryItems[0].numberHeld = 0;
        PlayerInventory.InventoryItems[1].numberHeld = 0;
        PlayerInventory.InventoryItems[2].numberHeld = 0;
        PlayerInventory.InventoryItems[3].numberHeld = 0;
        PlayerInventory.InventoryItems[4].numberHeld = 0;
        PlayerInventory.InventoryItems[5].numberHeld = 0;
        PlayerInventory.InventoryItems[6].numberHeld = 0;
        StarPointInventory.starPoints[0].numberHeld = 0;
        StarPointInventory.starPoints[1].numberHeld = 0;
        debriefingCount.swapGateCount = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
