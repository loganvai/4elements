using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipes : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    int counter = 10;

    private void OnEnable()
    {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        
        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    
    private void Spawn()
    {
        if (counter > 0)
        {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        counter--;
        }
    }
}
