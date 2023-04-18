using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraman;


    public void Interaction()
    {
        cameraman.SetActive(true);

        //PlayerController.PC.gameObject.SetActive(false);
        PlayerController.PC.setMove(false);
    }

    public void returnGame()
    {
        cameraman.SetActive(false);
        Debug.Log("Voltei");

        //PlayerController.PC.gameObject.SetActive(true);
        PlayerController.PC.setMove(true);
    }


}
