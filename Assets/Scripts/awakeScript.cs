using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeScript : MonoBehaviour
{
    [SerializeField]
    public GameObject player;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetTrigger("awake");
    }


    public void setPlayer()
    {
        player.SetActive(true);
        gameObject.SetActive(false);
    }


}
