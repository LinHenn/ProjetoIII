using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerInt : MonoBehaviour, IInteractible
{

    public void Interaction()
    {

        GetComponent<Animator>().SetTrigger("Open");
        if(gameObject.TryGetComponent<BoxCollider>(out BoxCollider component)) GetComponent<BoxCollider>().enabled = false;
        Destroy(this);

    }

}
