using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Pipe spawner
public class Pipes : MonoBehaviour
{
    // Pipe spawn stuff
    public GameObject Pipe;
    public float spawnRate = 4;
    private float timer = 0;
    public float heightOffset = 15;
    //public float randomTimer = Random.Range (-3f, 3f);
    
    void Start()
    {
        spawnPipe();
    }

    
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

    }

    // Spawns pipes in set location
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }




} 
