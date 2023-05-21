using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecureRoom : MonoBehaviour
{
    public int Room;

    [SerializeField]
    private bool info1;
    private bool info2;

    private void OnTriggerEnter(Collider other)
    {
        setSave();
    }

    public void Free035()
    {
        info1 = true;
    }

    public void FreeTime()
    {
        info2 = true;
    }

    public void setSave()
    {
        if(Room == 1)
        {
            Gamecontrol.GC.SG.is035Free = info1;
            Gamecontrol.GC.SG.SecureRoom1 = true;
            Gamecontrol.GC.SG.SecureRoom2 = false;
        }
        if(Room == 2)
        {
            Gamecontrol.GC.SG.timeComplete = info2;
            Gamecontrol.GC.SG.SecureRoom1 = false;
            Gamecontrol.GC.SG.SecureRoom2 = true;
        }

        Gamecontrol.GC.SG.saveBool();
    }


}
