using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ArchiveLocker: MonoBehaviour, IPuzzle
{
    [SerializeField] private TMP_Text targetText;

    [SerializeField] private float Answer; //resposta correta
    [SerializeField]
    private float sequence; //Sequencia do jogador


    public UnityEvent itHappens;


    public void letsPlay()
    {

        targetText.text = "0";
        sequence = 0;
    }

    public void AddNumber(float i)
    {
        sequence = sequence * 10;
        sequence += i;
        targetText.text = sequence.ToString();
    }

    public virtual void buttonStart()
    {
        if (sequence == Answer)
        {

            itHappens.Invoke();
            //StartCoroutine(waitToExplode());            
        }
        else Debug.Log("Nao bombou");
    }


    public void buttonCancel()
    {   
        Debug.Log("Cancelei");
        sequence = 0;
        targetText.text = "";
    }

}
