<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool agarrar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteracion")
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = this.gameObject;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteracion")
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = null;
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool agarrar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteracion")
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = this.gameObject;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteracion")
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = null;
        }
    }
}
>>>>>>> 151074ac0fe334417a6e895f3c887bbe3e5fc5cc
