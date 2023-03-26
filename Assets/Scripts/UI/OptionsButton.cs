using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;


public class OptionsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TMP_Text targetText;
    [SerializeField] private UnityEvent Happen;


    public void SetButton(OptionsDial dial)
    {
        targetText.text = dial.textOpt;
        Happen = dial.optEvent;
    }

    
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        //Debug.Log("Cursor Exiting " + name + " GameObject");
    }


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Debug.Log("Cursor Click " + name + " GameObject");
        Happen.Invoke();
    }
    


}
