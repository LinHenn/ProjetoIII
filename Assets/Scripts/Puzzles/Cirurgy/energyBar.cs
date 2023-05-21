using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBar : MonoBehaviour
{
    [SerializeField]
    public GameObject[] bars;

    public int count;

    public screenCirurgy SC;

    public void setEnergy()
    {
        count++;

        for(int i = 0; i < count; i++)
        {
            bars[i].SetActive(true);
        }

        if (count == 4) SC.setEnergy();
    }

}
