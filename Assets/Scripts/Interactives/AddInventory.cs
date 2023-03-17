using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInventory : MonoBehaviour, IInteractible
{
    public bool isToDestroy;
    public itemInventory item;

    public void Interaction()
    {
        Gamecontrol.GC.AddInventory(item);
        Destroy(this);


        if(isToDestroy) this.gameObject.SetActive(false);

    }
}
