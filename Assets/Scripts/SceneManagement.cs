using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void PlayGameOne()
    {
        SceneManager.LoadScene("SkripsiLevel01");
    }

    public void PlayGameTwo()
    {
        SceneManager.LoadScene("SkripsiLevel02");
    }

    public void PlayGameThree()
    {
        SceneManager.LoadScene("SkripsiLevel03");
    }

    public void PlayGameFour()
    {
        SceneManager.LoadScene("SkripsiLevel04");
    }

    public void PlayGameFive()
    {
        SceneManager.LoadScene("SkripsiLevel05");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
