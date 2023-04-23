using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoBase : MonoBehaviour
{
    public string namePT;

    public UnityEvent willHappen;
    public float distance = 5;
    protected float playerDist;

    private void Start()
    {
        if (Gamecontrol.GC.Linguagem == Language.Português) gameObject.name = namePT;
    }

    public void GetName()
    {
        playerDist = Vector3.Distance(transform.position, PlayerController.PC.transform.position);
        
        if(playerDist < distance) Gamecontrol.GC.setTarget(gameObject.name, true);
        else Gamecontrol.GC.setTarget(gameObject.name, false);
    }


    public virtual void willInteract()
    {
        if (!Gamecontrol.GC.mayInteract) return;
        Gamecontrol.GC.HaveInteracted();


        if (playerDist < distance)
        willHappen.Invoke();
    }

}
