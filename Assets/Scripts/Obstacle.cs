using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb; //rigidbody del objeto

    bool canPlace = true; //Indica si se puede soltar la pieza
    bool placed = false;  //Indica si la pieza ya fue ubicada

    public Material previewMaterial; //Para cuando no se ubicó aún
    public Material cantDropMaterial; //Para cuando no puede ser ubicada
    public Material actualMaterial;  //Para cuando ya fue ubicada

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //Se setea al material de previsualización
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Renderer>().material = previewMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //En caso de impactar contra el suelo
        if(collision.collider.CompareTag("Floor"))
        {
            //Seteamos kinematic para que el objeto quede quieto e indicamos que fue ubicado
            rb.isKinematic = true;
            placed = true;

            for (int i = 0; i < transform.childCount; i++)  //Cambiamos al material final
            {
                transform.GetChild(i).gameObject.GetComponent<Renderer>().material = actualMaterial;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!placed) //Si aún no fue ubicada la pieza
        {
            if (other.gameObject.CompareTag("Obstacle")) //Y está chocando con otro obstaculo
            {
                canPlace = false; //Indicamos que no se puede ubicar

                for (int i = 0; i < transform.childCount; i++) //Cambiamos al material correspondiente
                {
                    transform.GetChild(i).gameObject.GetComponent<Renderer>().material = cantDropMaterial;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!placed) //Si aún no fue ubicada la pieza
        {
            if (other.gameObject.CompareTag("Obstacle")) //Y dejar dechocar con otro obstaculo
            {
                canPlace = true; //indicamos que se puede ubicar

                for (int i = 0; i < transform.childCount; i++) //Seteamos al material de previsualización
                {
                    transform.GetChild(i).gameObject.GetComponent<Renderer>().material = previewMaterial;
                }
            }
        }
    }



    // -----------------------------------------------
    // ///////////GETTERS & SETTERS//////////////////
    //------------------------------------------------
    public void SetCanPlace(bool state)
    {
        canPlace = state;
    }

    public bool GetCanPlace()
    {
        return canPlace;
    }

    public void SetTriggers(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Collider>().isTrigger = state;
        }
    }

    public void SetNavObstacle(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<NavMeshObstacle>().enabled = state;
        }
    }

    public void SetGravity(bool state)
    {
        rb.useGravity = state;
    }
}
