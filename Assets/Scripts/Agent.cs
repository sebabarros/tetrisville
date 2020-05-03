using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 hitPoint;

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
        //bool clickOnFloor;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        

        if (Physics.Raycast(ray,out hit))
        {
            hitPoint = hit.point;
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                setTarget(hit.point);
            }
        }
    }

    void setTarget(Vector3 target)
    {
       agent.destination = target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitPoint, 2);
    }
}
