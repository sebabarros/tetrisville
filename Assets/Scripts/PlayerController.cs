using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 hitPoint;
    public GameObject[] pieces; //Las piezas de tetris a utilizar en orden
    int current;  //indice de la pieza actual

    // Start is called before the first frame update
    void Start()
    {
        current = 0; //Seteamos el indice a 0
    }

    // Update is called once per frame
    void Update()
    {
        //En caso de hacer click
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }

        //Chequea que el click impacte en el suelo
        void CheckClick()
        {
            RaycastHit hit; //Información del punto de impacto del raycast

            //Se traduce el click a coordenadas de mundo para el raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            //En caso de impactar
            if (Physics.Raycast(ray, out hit))
            {
                hitPoint = hit.point;

                //Se chequea si impacta contra el suelo y que sigan quedando piezas en la lista
                if (hit.collider.gameObject.CompareTag("Floor") && current < pieces.Length)
                {
                    DropPiece(hit.point);
                }
            }
        }
    }

    //Funcion para ubicar la pieza en la escena
    void DropPiece(Vector3 location)
    {
        //Se ubica el objeto metros arriba de la posición indicada
        Vector3 spawnPos = new Vector3(location.x, location.y + 8, location.z);
        Instantiate(pieces[current], spawnPos, Quaternion.identity);

        current++; //Incrementamos a la siguiente pieza
    }

    private void OnDrawGizmos()
    {
        //Dibujamos una esfera donde impacta el click
        Gizmos.DrawSphere(hitPoint, 2);
    }
}
