using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelComplete"))
        {
            PlayerPrefs.SetInt("LevelComplete", currentLevel);
        }

        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
