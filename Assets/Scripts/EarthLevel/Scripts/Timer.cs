using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    int day1;
    int month1;
    int year1;
    int day2;
    int month2;
    int year2;
    public Sprite sprite2;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] GameObject canvas1;
    [SerializeField] public TextMeshProUGUI inputText;
    [SerializeField] public TextMeshProUGUI inputText2;
    // Start is called before the first frame update
    void Start()
    {
        day1 = System.DateTime.Now.Day;
        month1 = System.DateTime.Now.Month;
        year1 = System.DateTime.Now.Year + 1;

        inputText.text = "GrowthDay " + $"{day1:D2}-{month1:D2}-{year1:D2}";


    }
    void Update()
        {

            day2 = System.DateTime.Now.Day;
            month2 = System.DateTime.Now.Month;
            year2 = System.DateTime.Now.Year;
            inputText2.text = "TodayDay " + $"{day2:D2}-{month2:D2}-{year2:D2}";
            if (day1 == day2 && month1== month2 && year1 == year2)
            {
                Invoke("canvasik",3);
                spriteRenderer.sprite = sprite2;
            }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas1.SetActive(true);
            Time.timeScale = 0;
        }

    }
     void canvasik()
    {
        canvas.SetActive(true);
    }
     
}




