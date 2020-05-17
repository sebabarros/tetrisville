using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam; //camara del jugador

    public Vector3 displacement; //Diferencia entre camara y agente

    public float increment = 0.3f; //velocidad de la cámara del mouse

    GameObject agent; //Agente actual

    bool camSwitch = true; //switch de camaras

    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.FindGameObjectWithTag("MainAgent");
    }

    // Update is called once per frame
    void Update()
    {
        //Switchea entre dos modos de cámara
        if (Input.GetButtonDown("Fire2"))
        {
            camSwitch = !camSwitch;
            Debug.Log(camSwitch);
        }

        CamBehaviour();
    }

    void CamBehaviour()
    {
        //En modo A la cámara sigue al agente con la separacion de displacemente
        if(camSwitch)
        {
            transform.position = agent.transform.position + displacement;
        }
        else
        {
            //En modo B el mouse mueve la cámara
            MouseCam();
        }
    }

    /// <summary>
    /// Mueve la cámara según la posición del mouse cuando se acerca
    /// a los bordes de la pantalla en los ejes horizontal y vertical
    /// </summary>
    void MouseCam()
    {
        if (Input.mousePosition.y <= Screen.height / 8)
            transform.position -= transform.forward * increment;
        else if (Input.mousePosition.y >= 7 * (Screen.height / 8))
        {
            print("aaaa");
            transform.position += transform.forward * increment;
        }
        
        if (Input.mousePosition.x <= Screen.width / 8)
            transform.position -= transform.right * increment;
        else if (Input.mousePosition.x > 7*(Screen.width / 8))
            transform.position += transform.right * increment;

    }
}
