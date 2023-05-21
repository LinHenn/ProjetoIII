using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class entranceSet : MonoBehaviour, IPuzzle
{
    [Header("The right answer")]
    public bool[] result;

    [Header("The player answer")]
    public bool[] mychoice;

    public UnityEvent isFinished;

    public void setTile(int index, bool choice)
    {
        mychoice[index] = choice;


        for(int i = 0; i < result.Length; i++)
        {
            if (result[i] != mychoice[i]) return;
        }

        isFinished.Invoke();
    }


    public void letsPlay()
    {

    }



}
