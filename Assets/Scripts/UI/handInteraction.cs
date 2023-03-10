using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class handInteraction : MonoBehaviour, IInteractible
{

    public string InteractionName;

    public UnityEvent willHappens;


    public void Interaction()
    {

        if (handScript.HS.itemHand.Name == InteractionName)
        {
            Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
            handScript.HS.setHand(handScript.HS.itemHand);
            willHappens.Invoke();
            Destroy(this);

        }

    }



}
