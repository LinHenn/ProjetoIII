using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraman;

    public bool maySee = true;


    public void Interaction()
    {
        if (Gamecontrol.GC.isPause) return;

        if (!maySee) return;

        maySee = false;

        cameraman.SetActive(true);

        //PlayerController.PC.gameObject.SetActive(false);
        PlayerController.PC.setMove(false);
    }

    public void returnGame()
    {
        if (Gamecontrol.GC.isPause) return;

        cameraman.SetActive(false);
        Debug.Log("Voltei");

        //PlayerController.PC.gameObject.SetActive(true);
        PlayerController.PC.setMove(true);
        StartCoroutine(waittotalk());
    }

    IEnumerator waittotalk()
    {
        yield return new WaitForSeconds(0.5f);
        maySee = true;

    }


}
