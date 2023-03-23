using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagar : MonoBehaviour
{
    public Button Earth;
    public Button Aqua;
    public Button Fire;
    public Button Air;
    int LevelComplete;

    private void Start()
    {
        Earth.interactable = true;
        Aqua.interactable = false;
        Fire.interactable = false;
        Air.interactable = false;

        LevelComplete = PlayerPrefs.GetInt("LevelComplete",1);

        switch (LevelComplete)
        {
            case 1:
                Earth.interactable = false;
                Aqua.interactable = true;
                break;
            case 2:
                Earth.interactable = false;
                Aqua.interactable = false;
                Fire.interactable = true;
                break;
            case 3:
                Earth.interactable = false;
                Fire.interactable = false;
                Air.interactable = true;
                break;
            case 4:
                Earth.interactable = false;
                Fire.interactable = false;
                Air.interactable = false;
                break;

        }


    }

    public void Transition(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void Reset()
    {
        Earth.interactable = true;
        Aqua.interactable = false;
        Fire.interactable = false;
        Air.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}


