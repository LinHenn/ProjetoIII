using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{
    public bool stopped, nonPlayer;

    public enum direction { sobe, desce};

    public direction moveDirection;

    public Vector3 offset;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("stop", true);
    }


    public void setStop()
    {
        stopped = true;

        nonPlayer = false;
        //anim.SetBool("stop", true);
    }


    public void letsMove() 
    {

        if (!stopped) return;

        offset = PlayerController.PC.gameObject.transform.position - transform.position;

        if(moveDirection == direction.desce)
        {
            stopped = false;

            //anim.SetBool("stop", false);
            anim.SetTrigger("Up");
            moveDirection = direction.sobe;
            //set direction to go
        }
        else
        {
            stopped = false;

            //anim.SetBool("stop", false);
            anim.SetTrigger("Down");
            moveDirection = direction.desce;
            //set direction to go
        }

    }



    public void setMove() //Apenas para mover o elevador sem o personagem
    {
        if (!stopped) return;

        nonPlayer = true;

        if (moveDirection == direction.desce)
        {
            stopped = false;

            //anim.SetBool("stop", false);
            anim.SetTrigger("Up");
            moveDirection = direction.sobe;
            //set direction to go
        }
        else
        {
            stopped = false;

            //anim.SetBool("stop", false);
            anim.SetTrigger("Down");
            moveDirection = direction.desce;
            //set direction to go
        }
    }



    private void FixedUpdate()
    {
        if (stopped) return;

        if (nonPlayer) return;

        PlayerController.PC.gameObject.transform.position = transform.position + offset;
    }
}
