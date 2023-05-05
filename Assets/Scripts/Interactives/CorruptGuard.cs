using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CorruptGuard : MonoBehaviour, IInteractible
{

    public int InteractionIndex;

    public UnityEvent willHappens;
    public UnityEvent willNotHappens;


    public void Interaction()
    {

        if (handScript.HS.itemHand.index == InteractionIndex)
        {
            /*
            if (isToRemove)
            {
                Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
                handScript.HS.setHand(handScript.HS.itemHand);
            }
            willHappens.Invoke();
            //Destroy(this);
            */
            willHappens.Invoke();
        }
        else willNotHappens.Invoke();

    }


}
