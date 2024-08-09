using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    PlayerInventory playerInventory;
    [SerializeField]
    StarPointInventory starPointInventory;
    [SerializeField]
    List<DialogueTrigger> dialogueManagerList = new List<DialogueTrigger>();
    [SerializeField]
    List<GameObject> skillActivated = new List<GameObject>();
    [SerializeField]
    List<GameObject> elementMonster = new List<GameObject>();
    [SerializeField]
    List<GameObject> bossMonster = new List<GameObject>();
    [SerializeField]
    List<TMP_Text> textMissionOne = new List<TMP_Text>();
    [SerializeField]
    List<TMP_Text> textMissionTwo = new List<TMP_Text>();
    [SerializeField]
    List<TMP_Text> textMissionThree = new List<TMP_Text>();
    [SerializeField]
    List<TMP_Text> textMissionFour = new List<TMP_Text>();
    [SerializeField]
    List<TMP_Text> textMissionFive = new List<TMP_Text>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        QuestOne();
        QuestTwo();
        QuestThree();
        QuestFour();
        QuestFive();
    }

    void QuestOne()
    {
        //Talk with Ghosto

        textMissionOne[0].color = Color.green;

        //Find NOT Rune
        if (playerInventory.InventoryItems[6].numberHeld == 1)
        {
            textMissionOne[1].color = Color.green;
        }
        //Find OR Rune
        if (playerInventory.InventoryItems[0].numberHeld == 1)
        {
            textMissionOne[2].color = Color.green;
        }

        //Fire skill & monster
        if (skillActivated[0].activeSelf)
        {
            textMissionOne[3].color = Color.green;
        }
        bool fireMonster = true;
        for (int i = 0; i < 3; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                fireMonster = false;
                break;
            }
        }
        if (fireMonster)
        {
            textMissionOne[4].color = Color.green;
        }

        //Find AND Rune
        if (playerInventory.InventoryItems[1].numberHeld == 1)
        {
            textMissionOne[5].color = Color.green;
        }

        //Water skill & monster
        if (skillActivated[1].activeSelf)
        {
            textMissionOne[6].color = Color.green;
        }
        bool waterMonster = true;
        for (int i = 3; i < 6; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                waterMonster = false;
                break;
            }
        }
        if (waterMonster)
        {
            textMissionOne[7].color = Color.green;
        }

        //Special skill & boss monster
        if (skillActivated[2].activeSelf)
        {
            textMissionOne[8].color = Color.green;
        }
        if (!bossMonster[0].activeSelf)
        {
            textMissionOne[9].color = Color.green;
        }

        //Star & point
        if (starPointInventory.starPoints[0].numberHeld >= 3)
        {
            textMissionOne[10].color = Color.green;
        }
        if (starPointInventory.starPoints[1].numberHeld >= 700)
        {
            textMissionOne[11].color = Color.green;
        }
    }

    void QuestTwo()
    {
        //Talk with Ghosto

        textMissionTwo[0].color = Color.green;

        //Find NOR Rune
        if (playerInventory.InventoryItems[2].numberHeld == 1)
        {
            textMissionTwo[1].color = Color.green;
        }

        //Wind skill & monster
        if (skillActivated[3].activeSelf)
        {
            textMissionTwo[2].color = Color.green;
        }
        bool windMonster = true;
        for (int i = 6; i < 9; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                windMonster = false;
                break;
            }
        }
        if (windMonster)
        {
            textMissionTwo[3].color = Color.green;
        }

        //Find NAND Rune
        if (playerInventory.InventoryItems[3].numberHeld == 1)
        {
            textMissionTwo[4].color = Color.green;
        }

        //Earth skill & monster
        if (skillActivated[4].activeSelf)
        {
            textMissionTwo[5].color = Color.green;
        }
        bool earthMonster = true;
        for (int i = 9; i < 12; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                earthMonster = false;
                break;
            }
        }
        if (earthMonster)
        {
            textMissionTwo[6].color = Color.green;
        }

        //Special skill & boss monster
        if (skillActivated[5].activeSelf)
        {
            textMissionTwo[7].color = Color.green;
        }
        if (!bossMonster[1].activeSelf)
        {
            textMissionTwo[8].color = Color.green;
        }

        //Star & point
        if (starPointInventory.starPoints[0].numberHeld >= 6)
        {
            textMissionTwo[9].color = Color.green;
        }
        if (starPointInventory.starPoints[1].numberHeld >= 1400)
        {
            textMissionTwo[10].color = Color.green;
        }
    }

    void QuestThree()
    {
        //Talk with Ghosto

        textMissionThree[0].color = Color.green;

        //All element skill & monster
        if (skillActivated[6].activeSelf &&
            skillActivated[7].activeSelf &&
            skillActivated[8].activeSelf &&
            skillActivated[9].activeSelf)
        {
            textMissionThree[1].color = Color.green;
        }
        bool elementMonster = true;
        for (int i = 12; i < 24; i++)
        {
            if (this.elementMonster[i].activeSelf)
            {
                elementMonster = false;
                break;
            }
        }
        if (elementMonster)
        {
            textMissionThree[2].color = Color.green;
        }

        //Special skill & boss monster
        if (skillActivated[10].activeSelf)
        {
            textMissionThree[3].color = Color.green;
        }
        if (!bossMonster[2].activeSelf)
        {
            textMissionThree[4].color = Color.green;
        }

        //Star & Point
        if (starPointInventory.starPoints[0].numberHeld >= 9)
        {
            textMissionThree[5].color = Color.green;
        }
        if (starPointInventory.starPoints[1].numberHeld >= 2700)
        {
            textMissionThree[6].color = Color.green;
        }
    }

    void QuestFour()
    {
        //Talk with Ghosto
        textMissionFour[0].color = Color.green;

        //Find XOR Rune
        if (playerInventory.InventoryItems[4].numberHeld == 1)
        {
            textMissionFour[1].color = Color.green;
        }

        //Light skill & monster
        if (skillActivated[11].activeSelf)
        {
            textMissionFour[2].color = Color.green;
        }
        bool lightMonster = true;
        for (int i = 24; i < 27; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                lightMonster = false;
                break;
            }
        }
        if (lightMonster)
        {
            textMissionFour[3].color = Color.green;
        }

        //Find XNOR Rune
        if (playerInventory.InventoryItems[4].numberHeld == 1)
        {
            textMissionFour[4].color = Color.green;
        }

        //Dark skill & monster
        if (skillActivated[12].activeSelf)
        {
            textMissionFour[5].color = Color.green;
        }
        bool darkMonster = true;
        for (int i = 27; i < 30; i++)
        {
            if (elementMonster[i].activeSelf)
            {
                darkMonster = false;
                break;
            }
        }
        if (darkMonster)
        {
            textMissionFour[6].color = Color.green;
        }

        //Special skill & boss monster
        if (skillActivated[13].activeSelf)
        {
            textMissionFour[7].color = Color.green;
        }
        if (!bossMonster[3].activeSelf)
        {
            textMissionFour[8].color = Color.green;
        }

        //Star & point
        if (starPointInventory.starPoints[0].numberHeld >= 12)
        {
            textMissionFour[9].color = Color.green;
        }
        if (starPointInventory.starPoints[1].numberHeld >= 3400)
        {
            textMissionFour[10].color = Color.green;
        }
    }

    void QuestFive()
    {
        //Talk with Ghosto
        textMissionFive[0].color = Color.green;

        //All element skill & monster
        if (skillActivated[14].activeSelf &&
            skillActivated[15].activeSelf &&
            skillActivated[16].activeSelf &&
            skillActivated[17].activeSelf &&
            skillActivated[18].activeSelf &&
            skillActivated[19].activeSelf)
        {
            textMissionFive[1].color = Color.green;
        }
        bool elementMonster = true;
        for (int i = 30; i < 48; i++)
        {
            if (this.elementMonster[i].activeSelf)
            {
                elementMonster = false;
                break;
            }
        }
        if (elementMonster)
        {
            textMissionFive[2].color = Color.green;
        }

        //Special skill & boss monster
        if (skillActivated[20].activeSelf)
        {
            textMissionFive[3].color = Color.green;
        }
        if (!bossMonster[2].activeSelf)
        {
            textMissionFive[4].color = Color.green;
        }

        //Star & Point
        if (starPointInventory.starPoints[0].numberHeld >= 15)
        {
            textMissionFive[5].color = Color.green;
        }
        if (starPointInventory.starPoints[1].numberHeld >= 5300)
        {
            textMissionFive[6].color = Color.green;
        }
    }
}
