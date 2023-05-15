using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automaticDoor : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entrei");
        anim.SetTrigger("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Sai");
        anim.SetTrigger("Close");
    }



}
