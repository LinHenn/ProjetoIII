using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CientistMove : MonoBehaviour
{
    NavMeshAgent _navMesh;
    public Animator anim;

    public Transform[] wayPoints;
    private int currentWayPoint;
    private int wayPointIndex;
    private float distanceWayPoint;


    // Start is called before the first frame update
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        anim.SetBool("walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        distanceWayPoint = Vector3.Distance(wayPoints[currentWayPoint].transform.position, transform.position);


        _navMesh.destination = wayPoints[currentWayPoint].transform.position;

        if (distanceWayPoint < 1)
        {
            RandomWayPoints();
            //_estadoAI = estadoDaAI.andando;
        }

    }

    void RandomWayPoints()
    {
        //currentWayPoint = Random.Range(0, wayPoints.Length);

        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length) wayPointIndex = 0;

        currentWayPoint = wayPointIndex;
    }

}
