using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CientistMove : MonoBehaviour
{
    [Header("É o chefe?")]
    [SerializeField]
    private bool imBoss;

    NavMeshAgent _navMesh;
    public Animator anim;

    public Transform[] wayPoints;
    private int currentWayPoint;
    private int wayPointIndex;
    private float distanceWayPoint;


    public FOVEnemy _cabeca;
    Transform alvo;
    [SerializeField]
    private Material rightSuit;




    // Start is called before the first frame update
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        anim.SetBool("walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (imBoss)
        {
            if (_cabeca.inimigosVisiveis.Count == 0)
            {
                distanceWayPoint = Vector3.Distance(wayPoints[currentWayPoint].transform.position, transform.position);
                _navMesh.destination = wayPoints[currentWayPoint].transform.position;

                if (distanceWayPoint < 1)
                {
                    RandomWayPoints();
                    //_estadoAI = estadoDaAI.andando;
                }
            }

            else
            {
                alvo = _cabeca.inimigosVisiveis[0];

                if (rightSuit != PlayerController.PC.suitPlayer)
                {
                    _navMesh.SetDestination(alvo.position);

                    if(Vector3.Distance(transform.position, PlayerController.PC.transform.position) < 2f)
                    {
                        _navMesh.SetDestination(transform.position);
                        anim.SetBool("walking", false);

                        GetComponent<InfoBase>().willHappen.Invoke();
                    }
                }

            }
        }


        else
        {
            distanceWayPoint = Vector3.Distance(wayPoints[currentWayPoint].transform.position, transform.position);
            _navMesh.destination = wayPoints[currentWayPoint].transform.position;

            if (distanceWayPoint < 1)
            {
                RandomWayPoints();
                //_estadoAI = estadoDaAI.andando;
            }
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
