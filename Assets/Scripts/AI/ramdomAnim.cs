using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramdomAnim : MonoBehaviour
{
    public string animName;

    
    private void Awake()
    {
        GetComponent<Animator>().SetTrigger(animName);
    }
}
