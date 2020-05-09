using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Vector3 hitPoint; //punto del suelo donde se ubica el cursor
    public GameObject[] pieces; //Las piezas de tetris a utilizar en orden

    
    int current;  //indice de la pieza actual

    GameObject currPiece;  //Pieza a manipular
    Obstacle currPieceObstacle; //Script Obstacle de la pieza a manipular

    //Contenedor para la pieza duplicada que se utiliza para previsualizar
    GameObject nextPieceModel;


    Vector3 storePos = new Vector3(0, 0, -200); //Posicion inicial de la pieza instanciada
    Vector3 previewPos = new Vector3(0, 0, -100); //Posición de la siguiente pieza a previsualizar

    // Start is called before the first frame update
    void Start()
    {
        current = 0; //Seteamos el indice a 0

        //Se instancia la nueva pieza lejos de la escena y se inhabilita su gravedad
        currPiece = Instantiate(pieces[current], storePos, Quaternion.identity) as GameObject;

        currPieceObstacle = currPiece.GetComponent<Obstacle>();
        currPieceObstacle.SetGravity(false);

        //Se instancia la pieza siguiente frente a la cámara de preview y se inhabilita su gravedad
        nextPieceModel = Instantiate(pieces[current + 1], previewPos, Quaternion.identity) as GameObject;
        nextPieceModel.GetComponent<Rigidbody>().useGravity = false;

        //Se setea la pieza a trigger y se inhabilita su componente NavMeshObstacle
        currPieceObstacle.SetTriggers(true);
        currPieceObstacle.SetNavObstacle(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMousePos();

        Rotate();
    }
       

    //Rota la figura de a incrementos de 30 grados 
    void Rotate()
    {
        currPiece.transform.Rotate(Vector3.up, Input.mouseScrollDelta.y * 30);
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

                //En caso de hacer click Y que sigan quedando piezas en la lista Y que no esté obstaculizado
                if (Input.GetMouseButtonDown(0) && current < pieces.Length && currPieceObstacle.GetCanPlace())
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
        currPiece.transform.position = displayPos;
    }

    //Funcion para ubicar la pieza en la escena
    void DropPiece(Vector3 location)
    {
        //La elevamos para que caiga
        currPiece.transform.position += new Vector3(0, 8, 0);

        //Se habilita la gravedad y el NavMeshObstacle, se desetea el Trigger
        currPieceObstacle.SetGravity(true);
        currPieceObstacle.SetNavObstacle(true);
        currPieceObstacle.SetTriggers(false);

        //Prepara próxima pieza
        SetNextPiece();
    }

    void SetNextPiece()
    {
        current++; //Incrementamos a la siguiente pieza

        //Se instancia la pieza siguiente, se deshabilita la gravedad
        currPiece = Instantiate(pieces[current], storePos, Quaternion.identity) as GameObject;

        currPieceObstacle = currPiece.GetComponent<Obstacle>();
        currPieceObstacle.SetGravity(false);

        //Se setea a Trigger e inhabilita el componente NavMeshObstacle
        currPieceObstacle.SetTriggers(true);
        currPieceObstacle.SetNavObstacle(false);


        //Destruimos la pieza previsualizada y la suplantamos por la siguiente
        Destroy(nextPieceModel);
        nextPieceModel = Instantiate(pieces[current + 1], previewPos, Quaternion.identity) as GameObject;
        nextPieceModel.GetComponent<Rigidbody>().useGravity = false;
    }    
}
