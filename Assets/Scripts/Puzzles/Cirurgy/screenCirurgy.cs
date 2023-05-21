using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenCirurgy : MonoBehaviour
{
    [SerializeField]
    private bool hasEnergy;

    [SerializeField]
    private bool puzzleDone;

    [SerializeField]
    private Material[] mats;


    public void setPuzzle()
    {
        puzzleDone = true;

        CheckScreen();
    }

    public void setEnergy()
    {
        hasEnergy = true;

        CheckScreen();
    }


    public void CheckScreen()
    {
        if(hasEnergy && !puzzleDone)
        {
            GetComponent<Renderer>().material = mats[0];
        }

        if (!hasEnergy && puzzleDone)
        {
            GetComponent<Renderer>().material = mats[1];
        }

        if (hasEnergy && puzzleDone)
        {
            GetComponent<Renderer>().material = mats[2];
        }
    }
}
