using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class handInteraction : MonoBehaviour, IInteractible
{

    public int InteractionIndex;
    public bool isToRemove;

    public UnityEvent willHappens;


    public void Interaction()
    {

        if (handScript.HS.itemHand.index == InteractionIndex)
        {
            if (isToRemove)
            {
                Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
                handScript.HS.setHand(handScript.HS.itemHand);
            }
            willHappens.Invoke();
            //Destroy(this);

        }

    }



}
