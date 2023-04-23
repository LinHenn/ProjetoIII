using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour, IInteractible
{

    public void Interaction()
    {

        if (Gamecontrol.GC.MissionComplete) Debug.Log("You Win");
        else Debug.Log("Tente novamente");
        
    }


}
