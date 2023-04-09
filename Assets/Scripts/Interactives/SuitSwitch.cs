using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitSwitch : MonoBehaviour, IInteractible
{
    public Material thisMaterial;
    public bool mayinteract;

    private void Start()
    {
        GetComponent<Renderer>().material = thisMaterial;
    }

    public void Interaction()
    {
        if (!mayinteract) return;
        Debug.Log(thisMaterial.name);
        var mat = PlayerController.PC.changeSuit(thisMaterial);
        thisMaterial = mat;
        GetComponent<Renderer>().material = thisMaterial;
        //Debug.Log(thisMaterial.name);

        StartCoroutine(willwait());
    }

    IEnumerator willwait()
    {
        mayinteract = false;
        yield return new WaitForSeconds(1);
        mayinteract = true;
    }
}
