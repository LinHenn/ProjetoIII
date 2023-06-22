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

    private energyBar _energybar;

    private void Awake()
    {
        Instance = this;
    }

    public void checkEnergy()
    {
        StartCoroutine(awaitTime());
    }

    IEnumerator awaitTime()
    {
        checkEnergy1();
        yield return new WaitForSeconds(0.5f);
        checkEnergy1();
    }


    private void checkEnergy1()
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
        _energybar = FindObjectOfType<energyBar>();
    }


    public void setLed(int index)
    {
        leds[index] = true;
        _energybar.setEnergy();

        if (leds[0] && leds[1] && leds[2] && leds[3]) isLightsOn.Invoke();
    }


}
