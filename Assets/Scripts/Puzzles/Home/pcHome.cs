using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class pcHome : MonoBehaviour, IPuzzle
{
    public string rightAnswer;

    public TextMeshProUGUI playeranswer;

    public GameObject[] windows;

    public UnityEvent willHappen;

    public UnityEvent endFinish;

    private int endGame = 0;


    public void letsPlay()
    {
        windows[0].SetActive(false);
        windows[1].SetActive(false);
        windows[2].SetActive(false);
        windows[3].SetActive(false);
    }

    public void checkPassword()
    {

        if (playeranswer.text.Contains(rightAnswer))
        {
            if (rightAnswer.Length + 1 == playeranswer.text.Length)
            {
                Debug.Log("Senha correta");
                willHappen.Invoke();
            }
            else Debug.Log("Errou");
        }

        playeranswer.text = "";


    }

    public void OnFinish()
    {
        endGame++;

        if (endGame >= 4) endFinish.Invoke();
    }
}
