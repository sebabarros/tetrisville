using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 hitPoint;
    public GameObject[] pieces; //Las piezas de tetris a utilizar en orden
    public Material previewMaterial;
    public Material actualMaterial;
    int current;  //indice de la pieza actual
    GameObject nextPiece;
    Vector3 storePos = new Vector3(0, 0, -100);

    // Start is called before the first frame update
    void Start()
    {
        current = 0; //Seteamos el indice a 0

        //Se instancia la pieza siguiente, se deshabilita el collider y utilizamos el 
        //material transparente
        nextPiece = Instantiate(pieces[current], storePos, Quaternion.identity) as GameObject;
        nextPiece.GetComponent<Collider>().enabled = false;
        nextPiece.GetComponent<Renderer>().material = previewMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMousePos();        
    }

    //Chequea que el click impacte en el suelo
    void CheckMousePos()
    {
        RaycastHit hit; //Información del punto de impacto del raycast

        //Se traduce el click a coordenadas de mundo para el raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //En caso de impactar
        if (Physics.Raycast(ray, out hit))
        {
            hitPoint = hit.point;

            //Se chequea si impacta contra el suelo
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                //Mostramos la pieza previa a su ubicación
                DisplayPiecePos(hitPoint);
                //En caso de hacer click y que sigan quedando piezas en la lista
                if (Input.GetMouseButtonDown(0) && current < pieces.Length)
                {
                    DropPiece(hitPoint);
                }
            }
        }
    }

    void DisplayPiecePos(Vector3 location)
    {
        //Se ubica el objeto en la posición indicada
        Vector3 displayPos = new Vector3(location.x, location.y + 1, location.z);
        nextPiece.transform.position = displayPos;
    }

    //Funcion para ubicar la pieza en la escena
    void DropPiece(Vector3 location)
    {
        //La elevamos para que caiga
        nextPiece.transform.position += new Vector3(0, 8, 0);

        //Se habilita collider, se ubica material final
        nextPiece.GetComponent<Collider>().enabled = true;
        nextPiece.GetComponent<Renderer>().material = actualMaterial;

        //Prepara próxima pieza
        SetNextPiece();
    }

    void SetNextPiece()
    {
        current++; //Incrementamos a la siguiente pieza

        //Se instancia la pieza siguiente, se deshabilita el collider y utilizamos el 
        //material transparente
        nextPiece = Instantiate(pieces[current], storePos, Quaternion.identity) as GameObject;
        nextPiece.GetComponent<Collider>().enabled = false;
        nextPiece.GetComponent<Renderer>().material = previewMaterial;
    }
}
