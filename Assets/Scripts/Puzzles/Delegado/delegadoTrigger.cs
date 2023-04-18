using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegadoTrigger : MonoBehaviour
{

    public bool complete; //Verdadeiro apenas se o jogador devolveu a chave 

    public CommumChat chatFail, chatSucess;
    public infoPuzzle sheriffPuzzle;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sheriff" || other.name == "Xerife")
        {
            if (!complete)
            {
                //chatFail.Interaction();
                sheriffPuzzle.setPuzzle(0);
                sheriffPuzzle.willInteract();
            }
            else
            {
                //chatSucess.Interaction();
                sheriffPuzzle.setPuzzle(0);
                sheriffPuzzle.setPuzzle(1);
                sheriffPuzzle.willInteract();
            }

            gameObject.SetActive(false);
        }
    }

    public void setComplete()
    {
        complete = true;
    }


}
