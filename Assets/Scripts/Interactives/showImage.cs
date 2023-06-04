using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour, IInteractible
{

    public Sprite folder;

    public bool mayWatch;

    public void Interaction()
    {
        if (!mayWatch) return;
        if (Gamecontrol.GC.iSeeYou) return;

        FolderScript.FS.setFolder(folder);
        Debug.Log("1");
    }


    public void isTalked()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        mayWatch = true;
    }

}
