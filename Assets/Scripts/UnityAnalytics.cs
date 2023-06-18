using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class UnityAnalytics : MonoBehaviour
{
    [SerializeField] SpawnManager[] killScores;
    [SerializeField] InventoryItem[] items;
    [SerializeField] AreaTransition[] transitions;
    [SerializeField] DialogueManager dialogs;

    void Update()
    {
        StreamWriter sw = new StreamWriter("C:\\Users\\Linggar\\Documents\\Unity\\Nusantara Dreams\\Test.txt");

        sw.WriteLine("killScore");
        int totalScore = 0;
        for (int i = 0; i < killScores.Length; i++)
        {
            totalScore += killScores[i].score;
        }
        sw.WriteLine(totalScore);


        sw.WriteLine("totalItem");
        int totalItem = 0;
        for (int i = 0; i < items.Length; i++)
        {
            totalItem += items[i].numberHeld;
        }
        sw.WriteLine(totalItem);


        sw.WriteLine("totalTransition");
        int totalTransition = 0;
        for (int i = 0; i < transitions.Length; i++)
        {
            totalTransition += transitions[i].countTransition;
        }
        sw.WriteLine(totalTransition);


        sw.WriteLine("npcDialog");
        sw.WriteLine(dialogs.npcDialog);

        //Close the file
        sw.Close();
    }
}
