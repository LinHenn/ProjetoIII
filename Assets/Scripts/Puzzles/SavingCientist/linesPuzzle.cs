using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class linesPuzzle : MonoBehaviour, IInteractible
{
    public bool takeThis;


    public void Interaction()
    {
        gameObject.SetActive(false);

        saveCientist.instance.setChoice(takeThis);
    }


}
