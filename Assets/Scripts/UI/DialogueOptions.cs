using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[System.Serializable]
public class OptionsDial
{
    public string textOpt;
    public UnityEvent optEvent;
}


public class DialogueOptions : MonoBehaviour
{
    public static DialogueOptions DO;

    [SerializeField] private List<OptionsButton> buttons;
    [SerializeField] private GameObject screen;

    public List<OptionsDial> options;



    private void Awake()
    {
        DO = this;
    }


    public void finishOptions()
    {
        foreach(var i in buttons)
        {
            i.gameObject.SetActive(false);
        }

        showMouse(false);

        screen.SetActive(false);

    }



    public void showMouse(bool i)
    {
        if (i)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    public void setOptions(List<OptionsDial> dialogues)
    {
        PlayerController.PC.setMove(false);

        options = dialogues;

        for(int i = 0; i < options.Count; i++)
        {
            //Debug.Log(options[i].textOpt);
            buttons[i].gameObject.SetActive(true);
            buttons[i].SetButton(dialogues[i]);
            //buttons[i].GetComponent<Button>().onClick = (Button.ButtonClickedEvent)options[i].optEvent;
        }

        screen.SetActive(true);

    }


}
