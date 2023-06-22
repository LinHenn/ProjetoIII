using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;


public class lockerPuzzler : MonoBehaviour, IPuzzle
{

    public List<int> RightAnswer;

    public List<int> playerResult;


    public UnityEvent itHappens;

    public bool isToCompare = true;

    private AudioSource AS;

    public void letsPlay()
    {
        AS = GetComponent<AudioSource>();
    }

    public void addResult(int index, int value)
    {
        AS.Play();

        playerResult[index] = value;
        if(isToCompare) compareResult();

    }

    public void compareResult()
    {
        int cont = 0;

        for(int i=0; i < RightAnswer.Count; i++)
        {
            if (RightAnswer[i] == playerResult[i]) cont++;
        }

        if (cont == RightAnswer.Count)
        {
            Debug.Log("Abriu");
            itHappens.Invoke();
        }

        else
        {
            Debug.Log("Nao abriu");            
        }

    }

    public void ClearResult()
    {
        playerResult.Clear();
    }


}
