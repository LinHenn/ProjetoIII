using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorScript : MonoBehaviour
{
    public bool stopped;

    public enum direction { sobe, desce};

    public direction moveDirection;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("stop", true);
    }


    public void setStop()
    {
        stopped = true;
        //anim.SetBool("stop", true);
    }

    public void letsMove() 
    {

        if (!stopped) return;

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
}
