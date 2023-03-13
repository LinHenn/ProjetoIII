using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AISimple : MonoBehaviour
{
    public FOVEnemy _cabeca;
    NavMeshAgent _navMesh;
    Transform alvo;
    Vector3 posicInicialDaAI;
    Vector3 ultimaPosicConhecida;
    float timerProcura;


    public Transform[] wayPoints;
    private int wayPointIndex;
    private int currentWayPoint;
    private float distanceWayPoint;


    enum estadoDaAI
    {
        parado, andando, seguindo, procurandoAlvoPerdido
    };
    estadoDaAI _estadoAI = estadoDaAI.parado;

    public enum ParadoouRotina
    {
        parado, rotina
    };

    public ParadoouRotina _paradoRotina;

    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        alvo = null;
        ultimaPosicConhecida = Vector3.zero;

        if (_paradoRotina == ParadoouRotina.parado) _estadoAI = estadoDaAI.parado;
        else _estadoAI = estadoDaAI.andando;

        posicInicialDaAI = transform.position;
        timerProcura = 0;
        RandomWayPoints();
    }

    void Update()
    {
        if (_paradoRotina == ParadoouRotina.rotina) { distanceWayPoint = Vector3.Distance(wayPoints[currentWayPoint].transform.position, transform.position); }

        if (_cabeca)
        {
            switch (_estadoAI)
            {
                case estadoDaAI.parado: //Para os Idle
                    _navMesh.SetDestination(posicInicialDaAI);
                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.seguindo;
                    }
                    break;

                case estadoDaAI.andando: // Para os de rotina
                    _navMesh.destination = wayPoints[currentWayPoint].transform.position;
                    if (distanceWayPoint < 2)
                    {
                        RandomWayPoints();
                        //_estadoAI = estadoDaAI.andando;
                    }
                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.seguindo;
                    }
                    break;

                case estadoDaAI.seguindo: //Para quando ver o Player
                    _navMesh.SetDestination(alvo.position);
                    if (!_cabeca.inimigosVisiveis.Contains(alvo))
                    {
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.procurandoAlvoPerdido;
                    }
                    break;

                case estadoDaAI.procurandoAlvoPerdido: //Para quando perder o jogador de vista
                    _navMesh.SetDestination(ultimaPosicConhecida);
                    timerProcura += Time.deltaTime;
                    if (timerProcura > 5)
                    {
                        timerProcura = 0;
                        //
                        if (_paradoRotina == ParadoouRotina.parado) _estadoAI = estadoDaAI.parado;
                        else _estadoAI = estadoDaAI.andando;
                        //_estadoAI = estadoDaAI.parado;
                        break;
                    }
                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.seguindo;
                    }
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("Morri");
    }


    void RandomWayPoints()
    {
        //currentWayPoint = Random.Range(0, wayPoints.Length);

        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length) wayPointIndex = 0;

        currentWayPoint = wayPointIndex;
    }
}
