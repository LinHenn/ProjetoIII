using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBase : MonoBehaviour
{



    public void GetName()
    {
        if (Gamecontrol.GC.TargetItem != gameObject.name)
        {
            //Debug.Log(gameObject.name);
            Gamecontrol.GC.setTarget(gameObject.name);
        }
    }

}
