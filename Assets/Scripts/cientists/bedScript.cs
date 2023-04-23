using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedScript : MonoBehaviour, IInteractible
{

    [SerializeField] GC_Cirurgy CirurgyGC;

    public void Interaction()
    {

        if (CirurgyGC.energyDone && CirurgyGC.puzzleDone)
        {
            Gamecontrol.GC.CompleteMission();
            Debug.Log("Dormi");
        }
        else Debug.Log("Nao Dormi");


    }


}
