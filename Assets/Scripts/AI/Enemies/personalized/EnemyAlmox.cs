using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlmox : MonoBehaviour, IInteractible
{
    public GameObject target;
    public Vector3 startPoint;

    public void Interaction()
    {
        startPoint = transform.position;

        GetComponent<AISimple>().posicInicialDaAI = target.transform.position;

        StartCoroutine(timeToReturn());
    }


    IEnumerator timeToReturn()
    {
        Debug.Log("vem");
        yield return new WaitForSeconds(120f);

        GetComponent<AISimple>().posicInicialDaAI = startPoint;

        Debug.Log("vai");

    }

}
