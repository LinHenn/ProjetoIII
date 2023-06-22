using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class entranceCtrl : MonoBehaviour
{
    public static entranceCtrl EC;

    [SerializeField]
    private bool[] puzzles;

    public UnityEvent isFinished;

    private AudioSource AS;


    private void Awake()
    {
        entranceCtrl.EC = this;
        AS = GetComponent<AudioSource>();
    }

    public void setFinished(int index)
    {
        puzzles[index] = true;

        if (puzzles[0] && puzzles[1] && puzzles[2]) { isFinished.Invoke(); AS.Play(); }
    }
}
