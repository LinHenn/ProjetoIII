using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class buttonArchiveLocker : MonoBehaviour
{
    [SerializeField] private ArchiveLocker locker;

    public void clicked()
    {
        locker.AddNumber(int.Parse(gameObject.name));
    }
}
