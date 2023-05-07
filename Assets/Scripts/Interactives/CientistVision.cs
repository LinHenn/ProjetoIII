using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CientistVision : MonoBehaviour, IInteractible
{

    public Material isTheRightSuit;

    public UnityEvent RightSuit, WrongSuit;


    public void Interaction()
    {
        if(isTheRightSuit == PlayerController.PC.suitPlayer)
        {
            Debug.Log("Roupa certa");
            RightSuit.Invoke();
        }
        else
        {
            Debug.Log("Roupa errada");
            WrongSuit.Invoke();
        }

    }

}
