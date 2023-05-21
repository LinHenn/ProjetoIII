using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveGame
{
    public static bool _secureRoom1, _is035Free, _secureRoom2, _timeComplete;


    public bool SecureRoom1; //Está na Sala Segura do primeiro andar
    public bool SecureRoom2; //Está no subsolo

    public bool is035Free; //Se soltou o 35
    public bool timeComplete; //Se a máquina do tempo foi utilizada

    public bool teste;


    public void startBool()
    {
        if (teste)
        {
            _secureRoom1 = SecureRoom1;
            _is035Free = is035Free;
            _secureRoom2 = SecureRoom2;
            _timeComplete = timeComplete;

        }
        else
        {
            SecureRoom1 = _secureRoom1;
            SecureRoom2 = _secureRoom2;
            is035Free = _is035Free;
            timeComplete = _timeComplete;
        }
        Debug.Log(_secureRoom1 + " " + _is035Free + " " + _secureRoom2 + " " + _timeComplete);

    }

    public void saveBool()
    {
        if (Gamecontrol.setHardcore) return;

        _secureRoom1 = SecureRoom1;
        _is035Free = is035Free;
        _secureRoom2 = SecureRoom2;
        _timeComplete = timeComplete;

        //Debug.Log(_secureRoom1 + " " + _is035Free + " " + _secureRoom2 + " " +_timeComplete);

    }

    public void clearSave()
    {
        _secureRoom1 = false;
        _is035Free = false;
        _secureRoom2 = false;
        _timeComplete = false;
        SecureRoom1 = false;
        is035Free = false;
        SecureRoom2 = false;
        timeComplete = false;
    }

}
