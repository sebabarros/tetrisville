using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //En caso de impactar contra el suelo
        if(collision.collider.CompareTag("Floor"))
        {
            //Seteamos kinematic para que el objeto quede quieto
            rb.isKinematic = true;
        }

    }
}
