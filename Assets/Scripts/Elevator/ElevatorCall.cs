using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCall : MonoBehaviour, IInteractible
{
    [SerializeField] elevatorScript elevator;

    public void Interaction()
    {

        elevator.setMove();

    }
}
