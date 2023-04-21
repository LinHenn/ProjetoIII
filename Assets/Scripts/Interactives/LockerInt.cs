using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerInt : MonoBehaviour, IInteractible
{

    public void Interaction()
    {

        GetComponent<Animator>().SetTrigger("Open");
        GetComponent<BoxCollider>().enabled = false;
        Destroy(this);

    }

}
