using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class UnityAnalytics : MonoBehaviour
{
    [SerializeField] SpawnManager[] killScore;
    [SerializeField] InventoryItem[] item;
    [SerializeField] AreaTransition[] transition;
    [SerializeField] DialogueManager dialog;

    void Update()
    {
        StreamWriter sw = new StreamWriter("C:\\Users\\Linggar\\Documents\\Unity\\Nusantara Dreams\\Test.txt");

        sw.WriteLine("killScore");
        int totalScore = 0;
        for (int i = 0; i < killScore.Length; i++)
        {
            totalScore += killScore[i].score;
        }
        sw.WriteLine(totalScore);


        sw.WriteLine("totalItem");
        int totalItem = 0;
        for (int i = 0; i < item.Length; i++)
        {
            totalItem += item[i].numberHeld;
        }
        sw.WriteLine(totalItem);


        sw.WriteLine("totalTransition");
        int totalTransition = 0;
        for (int i = 0; i < transition.Length; i++)
        {
            totalTransition += transition[i].countTransition;
        }
        sw.WriteLine(totalTransition);


        sw.WriteLine("npcDialog");
        sw.WriteLine(dialog.npcDialog);

        //Close the file
        sw.Close();
    }
}
