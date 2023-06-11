using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisorAI2 : MonoBehaviour
{
    public AISimple2 AICop;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AICop.checkSuit();
        }
    }
}
