using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{
    bool isclosed = false;

    bool estatico = true;

    public GameObject door;

    private void OnTriggerEnter(Collider coll)
    {
        if (!isclosed && estatico)
        {
            isclosed = true;

            door.transform.position -= new Vector3(0, 4.43f, 0);

            estatico = false;
        }
    }
}
