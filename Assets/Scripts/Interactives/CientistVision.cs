using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CientistVision : MonoBehaviour, IInteractible
{

    public Material isTheRightSuit;


    public void Interaction()
    {
        if(isTheRightSuit == PlayerController.PC.suitPlayer)
        {
            Debug.Log("Roupa certa");
        }
        else
        {
            Debug.Log("Roupa errada");
        }

    }

}
