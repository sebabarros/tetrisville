using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent; //componente navmeshAgent del agente
    GameObject[] destinations; //Array de las puertas disponibles
    Transform destination; //puerta de destino del agente

    // Start is called before the first frame update
    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("Destination");

        //Se elige un destino aleatorio de entre las puertas disponibles
        destination = destinations[Random.Range(0, destinations.Length)].transform;

        agent = GetComponent<NavMeshAgent>();

        //Seteo de destino del agente
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
