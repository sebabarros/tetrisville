using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    bool isSelected;
    Light thisLight;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        thisLight = GetComponentInChildren<Light>();

        thisLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleSelection()
    {
        thisLight.gameObject.SetActive(true);
    }

    //////////////////GETTERS & SETTERS////////////////////
    public void SelectDestination(bool selection)
    {
        isSelected = selection;

        if (isSelected) HandleSelection();
    }
}
