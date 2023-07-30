using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAlmox : MonoBehaviour, IInteractible
{
    public GameObject target;
    public Vector3 startPoint;

    public void Interaction()
    {
        startPoint = transform.position;

        GetComponent<AISimple>().GoTo(target.transform);

        //StartCoroutine(timeToReturn());
    }


    IEnumerator timeToReturn()
    {
        Debug.Log("vem");
        yield return new WaitForSeconds(120f);

        //GetComponent<AISimple>().posicInicialDaAI = startPoint;
        GetComponent<NavMeshAgent>().SetDestination(startPoint);

        Debug.Log("vai");

    }

}
