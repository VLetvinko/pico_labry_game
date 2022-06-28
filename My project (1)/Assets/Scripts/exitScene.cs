using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitScene : MonoBehaviour
{
    public void startScene()
    {
        timescale();
        SceneManager.LoadScene(0);
    }

    public void levelsScene()
    {
        timescale();
        SceneManager.LoadScene(1);
    }
    public void shopScene()
    {
        timescale();
        SceneManager.LoadScene(2);
    }
    public void randomMazeScene()
    {
        timescale();
        SceneManager.LoadScene(4);
    }

    public void nextLevel()
    {
        timescale();
        if (PlayerPrefs.GetString("CurrentScene") == "SampleScene")
        {
            int level = PlayerPrefs.GetInt("currentLevel")+1;
            PlayerPrefs.SetInt("currentLevel", level);
            SceneManager.LoadScene(3);
        }
        else randomMazeScene();
    }

    public void repeat()
    {
        timescale();
        if (PlayerPrefs.GetString("CurrentScene") == "SampleScene")
        {
            SceneManager.LoadScene(3);
        }
        else randomMazeScene();
    }
    private void timescale()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void AppOff()
    {
        Application.Quit();
    }
    public void TutorialScene()
    {
        SceneManager.LoadScene(7);
    }
}
