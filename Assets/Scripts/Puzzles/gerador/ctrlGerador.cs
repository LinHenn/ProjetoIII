using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ctrlGerador : MonoBehaviour, IPuzzle
{

    public static ctrlGerador Instance;
    public event Action OnClearEnter;

    public UnityEvent playEnergy;

    private bool isOn;


    public List<bool> leds;
    [Header("When all the lights is On")]
    public UnityEvent isLightsOn; //Quando todas as luzes forem acessas


    private void Awake()
    {
        Instance = this;
    }

    public void checkEnergy()
    {
        if(isOn)
        {
            OnClearEnter.Invoke();
        }
        else
        {
            playEnergy.Invoke();
        }

        isOn = !isOn;
    }


    public void letsPlay()
    {

    }


    public void setLed(int index)
    {
        leds[index] = true;

        if (leds[0] && leds[1] && leds[2] && leds[3]) isLightsOn.Invoke();
    }


}
