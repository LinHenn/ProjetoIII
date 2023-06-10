using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SheriffAI : MonoBehaviour, IInteractible
{
    public Transform cientist;
    public GameObject trigger;
    public Animator anim;
    public Animator animCientist;

    private Vector3 startPoint;
    [SerializeField] private Transform startPointCientist;

    private NavMeshAgent _navmesh;


    private void Awake()
    {
        _navmesh = GetComponent<NavMeshAgent>();
        startPoint = transform.position;
    }



    public void Interaction()
    {
        _navmesh.SetDestination(cientist.position);
        anim.SetBool("walking", true);

        Debug.Log("Ajuda ao velho amigo");

        //StartCoroutine(timeToReturn());
    }

    IEnumerator timeToReturn()
    {
        yield return new WaitForSeconds(120);

        returnTime();
        
    }

    public void returnTime()
    {
        trigger.SetActive(true);
        _navmesh.SetDestination(startPoint);
        cientist.gameObject.GetComponent<NavMeshAgent>().enabled = true;
        cientist.gameObject.GetComponent<NavMeshAgent>().SetDestination(startPointCientist.position);
        cientist.gameObject.GetComponent<infoPuzzle>().setPuzzle(1);
        animCientist.SetBool("walking", true);

        Debug.Log("Estou voltando");
    }
        


    private void FixedUpdate()
    {
        var distanceWayPoint = Vector3.Distance(startPoint, transform.position);
        var distanceWayPointCientist = Vector3.Distance(startPointCientist.position, cientist.position);

        if (distanceWayPoint < 1 && distanceWayPointCientist < 1)
        {
            anim.SetBool("walking", false);
            animCientist.SetBool("walking", false);
            Destroy(this);
        }

    }

}
