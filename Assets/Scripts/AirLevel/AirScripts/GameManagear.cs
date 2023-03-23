using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagear : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI Score;
    [SerializeField] public SpawnerPipes spawner;
    [SerializeField] public GameObject canvas;
    [SerializeField] public Slider slider;

    // Start is called before the first frame update

    public void IncreaseScore()
    {
        score++;
        Score.text = score.ToString();

    }
    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }
    void Start()
    {
        slider.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(score==10)
        {
            Invoke("canvasik", 3);
            
        }
        slider.value = score;
        
        
    }
        
            void canvasik()
            {
            canvas.SetActive(true);
            Time.timeScale = 0;
    }
   
}
