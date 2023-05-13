using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPuzzle : MonoBehaviour, IInteractible
{
    [SerializeField] private int Value;
    [SerializeField] private int rightValue;
    public int index;

    public MotimPuzzle MP;

    public bool mayMove = true;


    public void Interaction()
    {
        if (!mayMove) return;

        Value++;
        if (Value == 8) Value = 0;
        transform.rotation = Quaternion.Euler(Value * 45f, 0, -90);

        if (Value == rightValue)
        {
            MP.setGear(index, true);
        }
        else
        {
            MP.setGear(index, false);
        }

    }

    public void finished()
    {
        mayMove = false;
    }

}
