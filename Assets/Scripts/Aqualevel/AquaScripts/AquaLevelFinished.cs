using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AquaLevelFinished : MonoBehaviour
{
    public void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelComplete"))
        {
            PlayerPrefs.SetInt("LevelComplete", currentLevel);
        }

        SceneManager.LoadScene(0);
    }
}
