using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour, IInteractible
{
    [SerializeField] elevatorScript elevator;
    
    public void Interaction()
    {

        elevator.letsMove();


    }
}
