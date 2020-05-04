using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] destinations;
    Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("Destination");

        destination = destinations[Random.Range(0, destinations.Length)].transform;
        agent = GetComponent<NavMeshAgent>();

        setTarget(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void setTarget(Vector3 target)
    {
       agent.destination = target;
    }    
}
