using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void PlayGameStory()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiStory");
    }

    public void PlayGameOne()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiLevel01");
    }

    public void PlayGameTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiLevel02");
    }

    public void PlayGameThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiLevel03");
    }

    public void PlayGameFour()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiLevel04");
    }

    public void PlayGameFive()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkripsiLevel05");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
