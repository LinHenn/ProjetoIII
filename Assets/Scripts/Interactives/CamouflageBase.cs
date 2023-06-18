using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamouflageBase : MonoBehaviour, IInteractible
{
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject cameraman;
    [SerializeField] private Transform point;

    public enum boxType
    {
        Trashcan, DeathSign
    };
    public boxType _TypeBox = boxType.Trashcan;

    public void Interaction()
    {
        //Debug.Log("Escondi");

        cameraman.SetActive(true);
        body.SetActive(true);

        PlayerController.PC.gameObject.SetActive(false);

        GetComponent<AudioSource>().Play();

    }

    public void returnGame()
    {
        //Debug.Log("Voltei");

        cameraman.SetActive(false);
        body.SetActive(false);

        if (_TypeBox == boxType.Trashcan) PlayerController.PC.gameObject.transform.position = point.position;
        else PlayerController.PC.gameObject.transform.position = transform.position;

        //Debug.Log(point.position);
        //Debug.Log(PlayerController.PC.gameObject.transform.position);

        PlayerController.PC.gameObject.SetActive(true);
    }

}
