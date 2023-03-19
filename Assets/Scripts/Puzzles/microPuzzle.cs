using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class microPuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private TMP_Text targetText;

    [SerializeField] private float Answer;
    [SerializeField]
    private float sequence;


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
        if(sequence >= Answer)
        {
            Debug.Log("Explodiu");
            itHappens.Invoke();
        }
        else Debug.Log("Nao bombou");
    }


    public void buttonCancel()
    {
        Debug.Log("Cancelei");

        
        /*
        PlayerController.PC.setMove(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        */
    }


}
