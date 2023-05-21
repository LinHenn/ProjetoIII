using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;



public class codeCirurgy : MonoBehaviour, IPuzzle
{
    [Header("Resposta correta")] [SerializeField]
    private int[] rightAnswer;

    [SerializeField]
    private TMP_Text[] Screen;

    [Header("Opção do jogador")]
    [SerializeField]
    private int[] valueScreen;

    private int indexScreen;

    public UnityEvent itHappens;



    public void letsPlay()
    {
        indexScreen = 0;
    }


    public void setDigit(int value)
    {
        valueScreen[indexScreen] = value;
        Screen[indexScreen].text = value.ToString();

        indexScreen++;

        if(indexScreen == 6)
        {
            checkAnswer();
        }
    }


    public void cancelDigit()
    {
        ClearAnswer();
        PuzzleRef.PR.closePuzzle(7);
    }

    public void checkAnswer()
    {
        indexScreen = 0;
        bool isWrong = false;

        for(int i = 0; i < rightAnswer.Length; i++)
        {
            if (rightAnswer[i] != valueScreen[i]) isWrong = true;
        }


        if (isWrong)
        {
            ClearAnswer();
            return;
        }

        itHappens.Invoke();
    }

    public void ClearAnswer()
    {
        indexScreen = 0;
        foreach (var digit in Screen)
        {
            digit.text = "";
        }
    }



}
