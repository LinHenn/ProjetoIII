using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


[System.Serializable]
public class ChatText
{
    public string[] texts;
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
        chatScreen.text = Chat.texts[index];
        panelScreen.SetActive(true);

        PlayerController.PC.setMove(false);

    }



    public IEnumerator receptChat(ChatText CT)
    {
        Chat = CT;

        index = 0;
        chatScreen.text = Chat.texts[index];
        panelScreen.SetActive(true);

        PlayerController.PC.setMove(false);

        foreach(var talk in Chat.texts)
        {
             new WaitUntil(() => Input.GetAxis("Fire1") == 0);

            index++;
            chatScreen.text = Chat.texts[index];
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

        timer = 1f;


        if (index + 1 < Chat.texts.Length)
        {
            index++;
            //Debug.Log(Chat.texts[index]);
            chatScreen.text = Chat.texts[index];
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
