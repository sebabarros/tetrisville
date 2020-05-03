using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }

    void CheckClick()
    {
        bool clickOnFloor;
        RaycastHit hit;

        //RAYCAST

        //if(clickOnFloor) setTarget();
    }

    Vector3 setTarget(Vector3 target)
    {
        return target;
    }
}
