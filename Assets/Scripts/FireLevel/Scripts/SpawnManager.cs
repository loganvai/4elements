using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject Red;
    BoxCollider2D collider;
    [SerializeField] SliderController slider;
    [SerializeField] Movement mover;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas1;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas1.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Spawn()
    {
        collider = Red.GetComponent<BoxCollider2D>();
        collider.enabled = true;
        Red = Instantiate(Red, new Vector3(7.09f, Random.Range(-3.4f + (collider.size.y / 2), 3.25f - (collider.size.y / 2)), 0), Quaternion.identity);
        
        switch(slider.progress)
        {
            case 0:
               Red.transform.localScale = new Vector3(Red.transform.localScale.x, 1f, 1f);
                mover.speed = 7f;
               break;
            case 1:
                Red.transform.localScale = new Vector3(Red.transform.localScale.x, 0.75f, 1f);
                break;
                mover.speed = 8f;
            case 2:
                Red.transform.localScale = new Vector3(Red.transform.localScale.x, 0.5f, 1f);
                mover.speed = 9f;
                break;
            case 3:
                Red.transform.localScale = new Vector3(Red.transform.localScale.x, 0.25f, 1f);
                mover.speed = 10f;
                break;
            case 4:
                
                mover.enabled = false;
                canvas.SetActive(true);
                break;

        }
        

    }
    public void Destorrr()
    {
        Destroy(Red);
    }
}
