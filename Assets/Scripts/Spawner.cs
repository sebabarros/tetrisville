using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pieces;
    public Vector2 spawnSpace;
    public float spawnRate = 3;
    float timer;
    bool spawning = true;
    int current = 0;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(spawning)
        {

            if(timer >= spawnRate && current < pieces.Length)
            {
                Vector3 spawnPos = new Vector3(Random.Range(spawnSpace.x / 2, -spawnSpace.x / 2), 
                        transform.position.y, Random.Range(spawnSpace.y / 2, -spawnSpace.y / 2));
                Instantiate(pieces[current], spawnPos, Quaternion.identity);
                timer = 0;
                current++;
            }
        }
    }
}
