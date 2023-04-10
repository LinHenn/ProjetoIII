using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommumChat : MonoBehaviour, IInteractible
{
    public ChatText chat;    

    public bool mayChat = true;

    public void Interaction()
    {
        if (!mayChat) return;

        mayChat = false;

        ChatScript.CS.ReceiveChat(chat);
        
        //StartCoroutine(ChatScript.CS.receptChat(chat));



    }


    public void isTalked()
    {
        mayChat = false;
        PlayerController.PC.setMove(true);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        mayChat = true;
    }


}
