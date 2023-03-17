using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlmox : MonoBehaviour, IInteractible
{
    public GameObject target;

    public void Interaction()
    {

        GetComponent<AISimple>().posicInicialDaAI = target.transform.position;

    }

}
