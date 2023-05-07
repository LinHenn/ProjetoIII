using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ondmanChat : MonoBehaviour, IInteractible
{
    public static int standardChat = 1;
    public UnityEvent[] Chats;

    public UnityEvent[] RandomChats;


    public void Interaction()
    {
        if (standardChat != 0) letsStatic();
        else letsRandom();

    }


    void letsStatic()
    {
        //Debug.Log("static " +standardChat);
        switch(standardChat)
        {
            case 1:
                Chats[0].Invoke();
                standardChat = 0;
                break;
            case 2:
                Chats[1].Invoke();
                standardChat = 0;
                break;
            case 3:
                Chats[2].Invoke();
                standardChat = 0;
                break;
            case 4:
                Chats[3].Invoke();
                standardChat = 0;
                break;
            case 5:
                Chats[4].Invoke();
                standardChat = 0;
                break;
        }
    }

    void letsRandom()
    {

        int i = Random.Range(1, 6);
        //Debug.Log(i);
        switch (i)
        {
            case 1:
                RandomChats[0].Invoke();
                break;
            case 2:
                RandomChats[1].Invoke();
                break;
            case 3:
                RandomChats[2].Invoke();
                break;
            case 4:
                RandomChats[3].Invoke();
                break;
            case 5:
                RandomChats[4].Invoke();
                break;
            case 6:
                RandomChats[5].Invoke();
                break;
        }

    }


    public void setStandard(int index)
    {
        standardChat = index;
    }


}
