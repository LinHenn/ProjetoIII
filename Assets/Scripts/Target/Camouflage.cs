using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camouflage : MonoBehaviour
{

    public Transform target;

    public CamouflageBase basecam;

    public float timer = 0.5f;


    //
    RaycastHit hit = new RaycastHit();
    //

    void Update()
    {
        timer -= Time.deltaTime;

        //float eixo = Input.GetAxis("Mouse X");
        //Debug.Log(eixo);
        //transform.RotateAround(target.transform.position, new Vector3(0,eixo * 100,0), 800 * Time.deltaTime);

        //
        transform.RotateAround(target.position, transform.up, Input.GetAxis("Mouse X"));

        Vector3 rotacao = transform.eulerAngles;
        rotacao.z = 0;
        transform.eulerAngles = rotacao;

        transform.position = target.position - transform.forward * 2f;

        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            transform.position = hit.point + transform.forward * 0.1f;
        }

        //


        if (timer > 0) return; 

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            basecam.returnGame();
            timer = 0.5f;
        }
    }

}
