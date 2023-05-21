using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class bedScript : MonoBehaviour, IInteractible
{

    [SerializeField] GC_Cirurgy CirurgyGC;

    public UnityEvent itHappens;

    public void Interaction()
    {

        if (CirurgyGC.energyDone && CirurgyGC.puzzleDone)
        {
            Gamecontrol.GC.CompleteMission();
            itHappens.Invoke();
            Debug.Log("Dormi");
        }
        else Debug.Log("Nao Dormi");


    }


}
