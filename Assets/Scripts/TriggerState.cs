using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Serve apenas para ativar e desativar quando o jogador passar por cima
public class TriggerState : MonoBehaviour
{

    public UnityEvent willHappen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            willHappen.Invoke();
            gameObject.SetActive(false);
        }

    }


}
