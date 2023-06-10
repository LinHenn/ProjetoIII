using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;


public class OptionsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image img;
    [SerializeField] private TMP_Text targetText;
    [SerializeField] private UnityEvent Happen;


    public void SetButton(OptionsDial dial)
    {
        if(Gamecontrol.GC.Linguagem == Language.Português) targetText.text = dial.textOptPT;
        else targetText.text = dial.textOptEN;
        Happen = dial.optEvent;
    }

    
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
        img.color = new Color32(133, 133, 133, 255);        
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
        img.color = new Color32(255, 255, 255, 255);
    }


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Debug.Log("Cursor Click " + name + " GameObject");
        img.color = new Color32(255, 255, 255, 255);

        Happen.Invoke();
    }
    


}
