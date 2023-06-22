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

    private AudioSource AS;


    public void letsPlay()
    {

        targetText.text = "0";
        sequence = 0;

        AS = GetComponent<AudioSource>();
    }

    public void AddNumber(float i)
    {
        sequence = sequence * 10;
        sequence += i;
        targetText.text = sequence.ToString();

        AS.Play();
    }

    public virtual void buttonStart()
    {
        if(sequence >= Answer)
        {
            
            itHappens.Invoke();
            //StartCoroutine(waitToExplode());            
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
