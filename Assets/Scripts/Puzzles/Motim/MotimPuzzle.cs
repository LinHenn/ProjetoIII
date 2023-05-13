using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MotimPuzzle : MonoBehaviour
{

    public bool[] gears;

    public UnityEvent willHappen;


    public void setGear(int index, bool value)
    {
        gears[index] = value;

        if (gears[0] && gears[1] && gears[2] && gears[3]) willHappen.Invoke();
    }


}
