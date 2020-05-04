using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 hitPoint;
    public GameObject[] pieces;
    int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }

        void CheckClick()
        {
            //bool clickOnFloor;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                hitPoint = hit.point;
                if (hit.collider.gameObject.CompareTag("Floor") && current < pieces.Length)
                {
                    DropPiece(hit.point);
                }
            }
        }
    }

    void DropPiece(Vector3 location)
    {
        Vector3 spawnPos = new Vector3(location.x, location.y + 8, location.z);
        Instantiate(pieces[current], spawnPos, Quaternion.identity);
        current++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitPoint, 2);
    }
}
