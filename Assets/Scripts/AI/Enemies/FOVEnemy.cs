using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVEnemy : MonoBehaviour
{
    [Header("Geral")]
    public Transform cabecaInimigo;
    public enum TipoDeColisao
    {
        RayCast
    };
    public TipoDeColisao _tipoDeColisao = TipoDeColisao.RayCast;
    public enum TipoDeChecagem
    {
        _10PorSegundo, _20PorSegundo, OTempoTodo
    };
    public TipoDeChecagem _tipoDeChecagem = TipoDeChecagem.OTempoTodo;
    [Range(1, 50)]
    public float distanciaDeVisao = 10;

    [Header("Raycast")]
    public string tagDosInimigos = "Respawn";
    [Range(2, 180)]
    public float raiosExtraPorCamada = 20;
    [Range(5, 180)]
    public float anguloDeVisao = 120;
    [Range(1, 10)]
    public int numeroDeCamadas = 3;
    [Range(0.02f, 0.25f)]
    public float distanciaEntreCamadas = 0.1f;
    //
    [Space(10)]
    public List<Transform> inimigosVisiveis = new List<Transform>();
    List<Transform> listaTemporariaDeColisoes = new List<Transform>();
    LayerMask layerObstaculos;
    float timerChecagem = 0;

    private void Start()
    {
        timerChecagem = 0;
        if (!cabecaInimigo)
        {
            cabecaInimigo = transform;
        }
        // o operador ~ inverte o estado dos bits (0 passa a ser 1, e vice versa)

    }

    void Update()
    {


        if (_tipoDeChecagem == TipoDeChecagem._10PorSegundo)
        {
            timerChecagem += Time.deltaTime;
            if (timerChecagem >= 0.1f)
            {
                timerChecagem = 0;
                ChecarInimigos();
            }
        }
        if (_tipoDeChecagem == TipoDeChecagem._20PorSegundo)
        {
            timerChecagem += Time.deltaTime;
            if (timerChecagem >= 0.05f)
            {
                timerChecagem = 0;
                ChecarInimigos();
            }
        }
        if (_tipoDeChecagem == TipoDeChecagem.OTempoTodo)
        {
            ChecarInimigos();
        }
    }

    private void ChecarInimigos()
    {
        if (_tipoDeColisao == TipoDeColisao.RayCast)
        {
            float limiteCamadas = numeroDeCamadas * 0.5f;
            for (int x = 0; x <= raiosExtraPorCamada; x++)
            {
                for (float y = -limiteCamadas + 0.5f; y <= limiteCamadas; y++)
                {
                    float angleToRay = x * (anguloDeVisao / raiosExtraPorCamada) + ((180.0f - anguloDeVisao) * 0.5f);
                    Vector3 directionMultipl = (-cabecaInimigo.right) + (cabecaInimigo.up * y * distanciaEntreCamadas);
                    Vector3 rayDirection = Quaternion.AngleAxis(angleToRay, cabecaInimigo.up) * directionMultipl;
                    //
                    RaycastHit hitRaycast;
                    if (Physics.Raycast(cabecaInimigo.position, rayDirection, out hitRaycast, distanciaDeVisao))
                    {
                        if (!hitRaycast.transform.IsChildOf(transform.root) && !hitRaycast.collider.isTrigger)
                        {
                            if (hitRaycast.collider.gameObject.CompareTag(tagDosInimigos))
                            {
                                Debug.DrawLine(cabecaInimigo.position, hitRaycast.point, Color.red);
                                //
                                if (!listaTemporariaDeColisoes.Contains(hitRaycast.transform))
                                {
                                    listaTemporariaDeColisoes.Add(hitRaycast.transform);
                                }
                                if (!inimigosVisiveis.Contains(hitRaycast.transform))
                                {
                                    inimigosVisiveis.Add(hitRaycast.transform);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.DrawRay(cabecaInimigo.position, rayDirection * distanciaDeVisao, Color.green);
                    }
                }
            }
        }

        //remove da lista inimigos que não estão visiveis
        for (int x = 0; x < inimigosVisiveis.Count; x++)
        {
            if (!listaTemporariaDeColisoes.Contains(inimigosVisiveis[x]))
            {
                inimigosVisiveis.Remove(inimigosVisiveis[x]);
            }
        }
        listaTemporariaDeColisoes.Clear();
    }

}
