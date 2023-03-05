using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camouflage : MonoBehaviour
{

    public Transform target;

    public CamouflageBase basecam;

    public float timer = 0.5f;

    void Update()
    {
        timer -= Time.deltaTime;

        float eixo = Input.GetAxis("Mouse X");
        //Debug.Log(eixo);
        transform.RotateAround(target.transform.position, new Vector3(0,eixo * 100,0), 800 * Time.deltaTime);

        if (timer > 0) return; 

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            basecam.returnGame();
            timer = 0.5f;
        }
    }

}
