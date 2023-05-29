using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntranceDoor : MonoBehaviour, IInteractible
{
    public UnityEvent GoodEnd;
    public UnityEvent BadEnd;

    public void Interaction()
    {

        if (Gamecontrol.GC.SG.timeComplete)
        {
            Debug.Log("You Win");
            GoodEnd.Invoke();
        }
        else
        {
            Debug.Log("Tente novamente");
            BadEnd.Invoke();
        }
        
    }


}
