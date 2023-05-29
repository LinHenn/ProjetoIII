using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AISimple : MonoBehaviour
{
    public FOVEnemy _cabeca;
    public Animator anim;
    NavMeshAgent _navMesh;
    Transform alvo;
    [HideInInspector]
    public Vector3 posicInicialDaAI;
    Vector3 ultimaPosicConhecida;
    float timerProcura;


    public Transform[] wayPoints;
    private int wayPointIndex;
    private int currentWayPoint;
    private float distanceWayPoint;

    [SerializeField]
    private float surpriseTimer = 2; //o tempo que o cara fica surpreso
    private float countSurprise; //Contagem até surpriseTimer para começar a seguir


    enum estadoDaAI
    {
        parado, andando, surpreso, seguindo, procurandoAlvoPerdido
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

        if (_paradoRotina == ParadoouRotina.parado)
        {
            anim.SetBool("walking", false);
            _estadoAI = estadoDaAI.parado;
        }
        else
        {
            anim.SetBool("walking", true);
            _estadoAI = estadoDaAI.andando;
        }

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

                    if (_navMesh.remainingDistance < 0.5f) anim.SetBool("walking", false);
                    else anim.SetBool("walking", true);

                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        //_estadoAI = estadoDaAI.seguindo;
                        //anim.SetBool("walking", true);
                        _estadoAI = estadoDaAI.surpreso;
                        anim.SetBool("walking", false);
                        Debug.Log("ALI ESTA");
                    }
                    break;

                case estadoDaAI.andando: // Para os de rotina
                    _navMesh.destination = wayPoints[currentWayPoint].transform.position;
                    if (distanceWayPoint < 1)
                    {
                        RandomWayPoints();
                        //_estadoAI = estadoDaAI.andando;
                    }
                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        //_estadoAI = estadoDaAI.seguindo;
                        //anim.SetBool("walking", true);
                        _estadoAI = estadoDaAI.surpreso;
                        anim.SetBool("walking", false);
                        Debug.Log("UN FORASTERO");
                    }
                    break;

                case estadoDaAI.surpreso:
                    anim.SetBool("walking", false);
                    _navMesh.destination = transform.position;
                    countSurprise += Time.deltaTime;
                    if(countSurprise >= surpriseTimer)
                    {
                        countSurprise = 0;
                        _estadoAI = estadoDaAI.seguindo;
                        anim.SetBool("walking", true);

                        anim.SetBool("running", true);
                        _navMesh.speed = 7f;
                    }
                    break;

                case estadoDaAI.seguindo: //Para quando ver o Player
                    
                    _navMesh.SetDestination(alvo.position);
                    if (!_cabeca.inimigosVisiveis.Contains(alvo))
                    {
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.procurandoAlvoPerdido;
                        anim.SetBool("walking", true);

                        anim.SetBool("running", false);
                        _navMesh.speed = 3.5f;
                    }

                    //Checa se o jogador morre
                    if (Vector3.Distance(transform.position, PlayerController.PC.transform.position) < 1f)
                    {
                        Gamecontrol.GC.YouDied();
                        //Debug.Log("Morri");
                    }
                    //

                    break;

                case estadoDaAI.procurandoAlvoPerdido: //Para quando perder o jogador de vista
                    
                    _navMesh.SetDestination(ultimaPosicConhecida);
                    timerProcura += Time.deltaTime;

                    if (_navMesh.remainingDistance < 0.5f) anim.SetBool("walking", false);

                    if (timerProcura > 5)
                    {
                        timerProcura = 0;
                        //
                        if (_paradoRotina == ParadoouRotina.parado)
                        {
                            _estadoAI = estadoDaAI.parado;
                            //anim.SetBool("walking", false);
                        }
                        else _estadoAI = estadoDaAI.andando;
                        //_estadoAI = estadoDaAI.parado;
                        anim.SetBool("walking", true);
                        //Debug.Log("Perdi e estou voltando");
                        break;
                    }
                    if (_cabeca.inimigosVisiveis.Count > 0)
                    {
                        alvo = _cabeca.inimigosVisiveis[0];
                        ultimaPosicConhecida = alvo.position;
                        _estadoAI = estadoDaAI.seguindo;
                        anim.SetBool("walking", true);

                        anim.SetBool("running", true);
                        _navMesh.speed = 7f;

                    }
                    break;
            }
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {

        if(Vector3.Distance(transform.position, PlayerController.PC.transform.position) < 2f) Debug.Log("Morri");
    }*/


    void RandomWayPoints()
    {
        //currentWayPoint = Random.Range(0, wayPoints.Length);

        wayPointIndex++;
        if (wayPointIndex >= wayPoints.Length) wayPointIndex = 0;

        currentWayPoint = wayPointIndex;
    }
}
