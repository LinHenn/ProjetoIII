using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class blockCientist : MonoBehaviour
{

    public UnityEvent cientistBrave;


    private void OnTriggerEnter(Collider other)
    {
        cientistBrave.Invoke();
    }
}
