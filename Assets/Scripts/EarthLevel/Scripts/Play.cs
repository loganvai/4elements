using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    
    void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    // Update is called once per frame
    public void Resume()
    {

        Time.timeScale = 1;
        
        canvas.SetActive(false);
        
    }
}
