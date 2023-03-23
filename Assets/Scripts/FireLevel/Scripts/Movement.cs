using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 endPoint;
    [SerializeField] public float speed = 5f;
    [SerializeField] public SpawnManager spawnManager;
    GameObject trigger;
    [SerializeField] public SliderController slidercontroller;

    private bool isPlayerOverlapping;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint = new Vector3(transform.position.x, 3.21f, transform.position.z);
    }

    // Update is called once per frame
    private bool movingTowardsStart = true;

    void Update()
    {
        if (movingTowardsStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
            if (transform.position == startPoint)
            {
                movingTowardsStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            if (transform.position == endPoint)
            {
                movingTowardsStart = true;
            }
        }

        if (isPlayerOverlapping && Input.GetKeyDown(KeyCode.Space))
        {
            slidercontroller.UpdateProgress();
            Destroy(spawnManager.Red);
            spawnManager.Spawn();
            
        }
        else if(!isPlayerOverlapping && Input.GetKeyDown(KeyCode.Space))
        {

            slidercontroller.RemoveProgress();
            Destroy(spawnManager.Red);
            spawnManager.Spawn();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            isPlayerOverlapping = true;
            trigger = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Red")
        {
            isPlayerOverlapping = false;
        }
    }
}
