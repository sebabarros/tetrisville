using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public float reachDistance = 2.0f;
    NavMeshAgent agent; //componente navmeshAgent del agente
    GameObject[] destinations; //Array de las puertas disponibles
    Transform destination; //puerta de destino del agente
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        destinations = GameObject.FindGameObjectsWithTag("Destination");

        //Se elige un destino aleatorio de entre las puertas disponibles
        destination = destinations[Random.Range(0, destinations.Length)].transform;

        destination.GetComponent<Destination>().SelectDestination(true);

        agent = GetComponent<NavMeshAgent>();

        //Seteo de destino del agente
        setTarget(destination.position);

        InvokeRepeating("ReachDest", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ReachDest()
    {
        if (Vector3.Distance(transform.position, destination.position) < reachDistance)
        {
            SetAnimation("reachedDest", true);
        }
    }

    void SetAnimation(string name, bool value)
    {
        anim.SetBool(name, value);
    }

    void setTarget(Vector3 target)
    {
       agent.destination = target;
    }

    private void OnDrawGizmos()
    {
        if (agent)
        {
            for (int i = 0; i < agent.path.corners.Length; i++)
                Gizmos.DrawSphere(agent.path.corners[i], 0.5f);
        }
    }
}
