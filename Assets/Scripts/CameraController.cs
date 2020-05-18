using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera cam; //camara del jugador

    public Vector3 displacement; //Diferencia entre camara y agente

    public float increment = 0.3f; //velocidad de la cámara del mouse

    public Text camIndicator;

    GameObject agent; //Agente actual

    bool camSwitch = false; //switch de camaras

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
        //En modo A la cámara sigue al agente con la separacion de displacement
        if(camSwitch)
        {
            transform.position = agent.transform.position + displacement;
            camIndicator.text = "CAMARA FIJA";
        }
        else
        {
            //En modo B el mouse mueve la cámara
            MouseCam();

            camIndicator.text = "CAMARA LIBRE";
        }
    }

    /// <summary>
    /// Mueve la cámara según la posición del mouse cuando se acerca
    /// a los bordes de la pantalla en los ejes horizontal y vertical
    /// </summary>
    void MouseCam()
    {
        if (Input.mousePosition.y <= Screen.height / 8)
        {
            if (Input.mousePosition.y <= Screen.height / 16)
            {
                transform.position -= transform.forward * increment * 3f * Time.deltaTime;
                return;
            }
            transform.position -= transform.forward * increment * Time.deltaTime;
        }
        else if (Input.mousePosition.y >= 7 * (Screen.height / 8))
        {
            if (Input.mousePosition.y >= 15 * (Screen.height / 16))
            {
                transform.position += transform.forward * increment * 3f * Time.deltaTime;
                return;
            }
            transform.position += transform.forward * increment * Time.deltaTime;
        }

        if (Input.mousePosition.x <= Screen.width / 8)
        {
            if (Input.mousePosition.x <= Screen.width / 16)
            {
                transform.position -= transform.right * increment * 3f * Time.deltaTime;
                return;
            }
            transform.position -= transform.right * increment * Time.deltaTime;
        }
        else if (Input.mousePosition.x > 7 * (Screen.width / 8))
        {
            if (Input.mousePosition.x >= 15* (Screen.width / 16))
            {
                transform.position += transform.right * increment * 3f * Time.deltaTime;
                return;
            }
            transform.position += transform.right * increment * Time.deltaTime;
        }

    }
}
