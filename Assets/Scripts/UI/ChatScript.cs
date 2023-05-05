using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


[System.Serializable]
public class ChatText
{
    public string[] textsPT;
    public string[] textsEN;
    public UnityEvent happen;
}




public class ChatScript : MonoBehaviour
{
    public static ChatScript CS;

    [SerializeField] private GameObject panelScreen;
    [SerializeField] private TMP_Text chatScreen;
    [SerializeField] private ChatText Chat;
    [SerializeField]
    private int index;
    [SerializeField]
    private float timer;

    private void Awake()
    {
        CS = this;
    }



    public void ReceiveChat(ChatText CT)
    {

        Chat = CT;


        index = 0;
        if(Gamecontrol.GC.Linguagem == Language.Português) chatScreen.text = Chat.textsPT[index];
        else chatScreen.text = Chat.textsEN[index];

        panelScreen.SetActive(true);

        PlayerController.PC.setMove(false);

    }



    public IEnumerator receptChat(ChatText CT)
    {
        Chat = CT;

        index = 0;
        if (Gamecontrol.GC.Linguagem == Language.Português) chatScreen.text = Chat.textsPT[index];
        else chatScreen.text = Chat.textsEN[index];
        panelScreen.SetActive(true);

        PlayerController.PC.setMove(false);

        if (Gamecontrol.GC.Linguagem == Language.Português)
        {
            foreach (var talk in Chat.textsPT)
            {
                new WaitUntil(() => Input.GetAxis("Fire1") == 0);

                index++;
                chatScreen.text = Chat.textsPT[index];
            }
        }

        else
        {
            foreach (var talk in Chat.textsPT)
            {
                new WaitUntil(() => Input.GetAxis("Fire1") == 0);

                index++;
                chatScreen.text = Chat.textsPT[index];
            }
        }


        Chat.happen.Invoke();

        panelScreen.SetActive(false);

        index = 0;

        PlayerController.PC.setMove(true);

        yield return true;

    }



    
    private void Update()
    {

        if (!panelScreen.activeSelf) return;


        timer -= Time.deltaTime;

        if (Input.GetAxis("Fire1") == 0) return;

        if (timer >= 0) return;

        timer = 0.5f;


        if (Gamecontrol.GC.Linguagem == Language.Português)
        {
            if (index + 1 < Chat.textsPT.Length)
            {
                index++;
                //Debug.Log(Chat.texts[index]);
                chatScreen.text = Chat.textsPT[index];
            }

            else
            {

                //Debug.Log("Acabou");

                Chat.happen.Invoke();

                panelScreen.SetActive(false);

                index = 0;

                //PlayerController.PC.setMove(true);

            }
        }

        else
        {
            if (index + 1 < Chat.textsEN.Length)
            {
                index++;
                //Debug.Log(Chat.texts[index]);
                chatScreen.text = Chat.textsEN[index];
            }

            else
            {

                //Debug.Log("Acabou");

                Chat.happen.Invoke();

                panelScreen.SetActive(false);

                index = 0;

                //PlayerController.PC.setMove(true);

            }
        }



    }



}
