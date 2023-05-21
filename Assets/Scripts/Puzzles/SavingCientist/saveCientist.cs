using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class saveCientist : MonoBehaviour
{
    public static saveCientist instance;
    
    [SerializeField] private Material[] ledMat;

    [SerializeField]
    private int mistakes = 0;

    [SerializeField]
    private int correct = 0;

    [SerializeField]
    private GameObject[] lamps;


    public UnityEvent isFree;

    public UnityEvent isDead;

    private bool isFinished = false;



    private void Awake()
    {
        instance = this;
    }


    public void setChoice(bool i)
    {
        if (isFinished) return;

        if (i)
        {

            correct++;

            if (correct == 5)
            {
                isFinished = true;
                Debug.Log("Libertou");
                isFree.Invoke();
                lamps[0].GetComponent<Renderer>().material = ledMat[1];
                lamps[1].GetComponent<Renderer>().material = ledMat[1];
            }
        }

        else
        {
            mistakes++;

            if (mistakes == 1)
            {
                lamps[0].GetComponent<Renderer>().material = ledMat[0];
            }

            else
            {
                lamps[1].GetComponent<Renderer>().material = ledMat[0];

                isFinished = true;
                Debug.Log("Morreu");
                isDead.Invoke();
            } 
        }
    }


}
