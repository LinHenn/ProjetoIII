using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class getInfo : MonoBehaviour, IInteractible
{

    public UnityEvent isHappen;

    public void Interaction()
    {
        isHappen.Invoke();
        /*
        Debug.Log("Interacted with" +gameObject.name);

        Destroy(gameObject); //Only Test
        */
    }
}
