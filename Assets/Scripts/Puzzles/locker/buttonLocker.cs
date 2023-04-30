using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class buttonLocker : MonoBehaviour
{
    [SerializeField] private lockerPuzzler locker;
    [SerializeField] private TMP_Text lockNumber;

    public int value;


    public void clicked()
    {
        value++;
        if (value == 10) value = 0;

        locker.addResult(int.Parse(gameObject.name), value);
        lockNumber.text = value.ToString();
    }


}
