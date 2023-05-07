using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveGame
{
    public static bool _secureRoom1, _is035Free, _secureRoom2;


    public bool SecureRoom1; //Se chegou na Sala Segura do primeiro andar
    public bool is035Free; //Se soltou o 35

    public bool SecureRoom2; //Se chegou no subsolo

    public bool teste;


    public void startBool()
    {
        if (teste)
        {
            _secureRoom1 = SecureRoom1;
            _is035Free = is035Free;
            _secureRoom2 = SecureRoom2;
        }
        else
        {
            SecureRoom1 = _secureRoom1;
            SecureRoom2 = _secureRoom2;
            is035Free = _is035Free;
        }
        //Debug.Log(_secureRoom1 + " " + _is035Free + " " + _secureRoom2);

    }

    public void saveBool()
    {

        _secureRoom1 = SecureRoom1;
        _is035Free = is035Free;
        _secureRoom2 = SecureRoom2;

        //Debug.Log(_secureRoom1 + " " + _is035Free + " " + _secureRoom2);

    }

    public void clearSave()
    {
        _secureRoom1 = false;
        _is035Free = false;
        _secureRoom2 = false;
        SecureRoom1 = false;
        is035Free = false;
        SecureRoom2 = false;
    }

}
