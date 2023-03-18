using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoBase : MonoBehaviour
{

    public UnityEvent willHappen;
    public float distance = 5;
    protected float playerDist;


    public void GetName()
    {
        playerDist = Vector3.Distance(transform.position, PlayerController.PC.transform.position);
        
        if(playerDist < distance) Gamecontrol.GC.setTarget(gameObject.name, true);
        else Gamecontrol.GC.setTarget(gameObject.name, false);
    }


    public virtual void willInteract()
    {
        if(playerDist < distance)
        willHappen.Invoke();
    }

}
