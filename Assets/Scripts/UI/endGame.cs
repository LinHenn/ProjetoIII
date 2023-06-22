using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public void Finish()
    {
        //retorna para o menu e zera os checkpoints
        Gamecontrol.GC.GoToMenu();
    }
}
