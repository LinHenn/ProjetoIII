using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LockPrisionerAlaC : MonoBehaviour, IInteractible
{
    public int indexCompare;

    public UnityEvent willHappen;

    public UnityEvent notHappen;


    public void Interaction()
    {

        if (handScript.HS.itemHand.index == indexCompare)
        {
            //Debug.Log("Abriu");
            GetComponent<Animator>().SetTrigger("Open");

            willHappen.Invoke();
        }

        else notHappen.Invoke();


    }

}
