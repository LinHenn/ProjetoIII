using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screens : MonoBehaviour
{
    public void endScreen()
    {
        gameObject.SetActive(false);
    }

    public void nextScreen()
    {
        flashback.instance.nextScreen();
        //Debug.Log("proximo");
    }
}
