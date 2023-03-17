using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorLock : MonoBehaviour, IInteractible
{
    public int indexCompare;

    public UnityEvent willHappen;


    public void Interaction()
    {
        if (handScript.HS.itemHand.index == indexCompare)
        {
            Debug.Log("Abriu");
            GetComponent<Animator>().SetTrigger("Open");

            willHappen.Invoke();
            /*
            Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
            handScript.HS.setHand(handScript.HS.itemHand);
            */
        }
            
        else Debug.Log("Abriu nao");

        //this.gameObject.SetActive(false);
    }



}
