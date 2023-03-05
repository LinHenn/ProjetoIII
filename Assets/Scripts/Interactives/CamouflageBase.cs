using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamouflageBase : InfoBase, IInteractible
{
    [SerializeField] private GameObject cameraman;
    [SerializeField] private GameObject body;

    public void Interaction()
    {
        Debug.Log("Escondi");

        cameraman.SetActive(true);
        body.SetActive(true);

        PlayerController.PC.gameObject.SetActive(false);

    }

    public void returnGame()
    {
        Debug.Log("Voltei");

        cameraman.SetActive(false);
        body.SetActive(false);

        PlayerController.PC.gameObject.SetActive(true);
    }

}
