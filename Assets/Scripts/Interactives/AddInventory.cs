using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInventory : InfoBase, IInteractible
{
    public itemInventory item;

    public void Interaction()
    {
        Gamecontrol.GC.AddInventory(item);

        this.gameObject.SetActive(false);
    }
}
