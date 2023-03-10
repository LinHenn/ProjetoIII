using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoBase : MonoBehaviour
{

    public UnityEvent willHappen;


    public void GetName()
    {
        if (Gamecontrol.GC.TargetItem != gameObject.name)
        {
            //Debug.Log(gameObject.name);
            Gamecontrol.GC.setTarget(gameObject.name);
        }
    }


    public virtual void willInteract()
    {
        willHappen.Invoke();
    }

}
