using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDiscard : MonoBehaviour, IInteractible
{

    public void Interaction()
    {
        
        Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
        handScript.HS.setHand(handScript.HS.itemHand);

    }

}
