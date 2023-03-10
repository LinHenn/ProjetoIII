using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getInfo : MonoBehaviour, IInteractible
{


    public void Interaction()
    {
        Debug.Log("Interacted with" +gameObject.name);

        Destroy(gameObject); //Only Test
    }
}
