using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SheriffAI : MonoBehaviour, IInteractible
{
    public Transform cientist;

    private Vector3 startPoint;

    private NavMeshAgent _navmesh;


    private void Awake()
    {
        _navmesh = GetComponent<NavMeshAgent>();
        startPoint = transform.position;
    }



    public void Interaction()
    {
        _navmesh.SetDestination(cientist.position);

        Debug.Log("Ajuda ao velho amigo");

        StartCoroutine(timeToReturn());
    }

    IEnumerator timeToReturn()
    {

        yield return new WaitForSeconds(100);

        _navmesh.SetDestination(startPoint);
        Debug.Log("Estou voltando");
    }

}