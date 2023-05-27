using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class pcInfo : MonoBehaviour, IPuzzle
{
    public string rightAnswer;

    public TextMeshProUGUI playeranswer;

    public GameObject[] windows;

    public UnityEvent willHappen;
 
    
    public void letsPlay()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(false);
        windows[2].SetActive(false);
    }

    public void checkPassword()
    {
        
        if(playeranswer.text.Contains(rightAnswer))
        {
            if (rightAnswer.Length + 1 == playeranswer.text.Length) Debug.Log("Senha correta");
            willHappen.Invoke();
        }

        playeranswer.text = "";


    }


}
