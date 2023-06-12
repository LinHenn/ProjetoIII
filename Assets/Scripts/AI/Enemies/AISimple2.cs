using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AISimple2 : MonoBehaviour
{

    public bool questComplete = false;


    public Material isTheRightSuit;
    public UnityEvent rightSuit, wrongSuit;


    public void checkSuit()
    {
        if (questComplete) return;

        if (isTheRightSuit == PlayerController.PC.suitPlayer)
        {
            rightSuit.Invoke();
            //_estadoAI = estadoDaAI.parado;
            questComplete = true;
        }
        else
        {
            wrongSuit.Invoke();
        }
    }


}
