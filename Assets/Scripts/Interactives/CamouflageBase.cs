using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamouflageBase : MonoBehaviour, IInteractible
{
    [SerializeField] private GameObject cameraman;
    [SerializeField] private GameObject body;
    //[SerializeField] private GameObject point;

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

        PlayerController.PC.gameObject.transform.position = transform.position;
        PlayerController.PC.gameObject.SetActive(true);
    }

}
