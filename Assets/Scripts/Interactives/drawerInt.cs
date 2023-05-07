using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerInt : MonoBehaviour, IInteractible
{
    public void Interaction()
    {

        GetComponent<Animator>().SetTrigger("Open");

    }
}
