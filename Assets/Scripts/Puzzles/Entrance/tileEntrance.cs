using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileEntrance : MonoBehaviour
{
    [SerializeField]
    private bool isOn;

    [SerializeField]
    private Image thisImg;

    [SerializeField]
    private entranceSet ES;


    public void isClicked()
    {
        isOn = !isOn;

        if(isOn) thisImg.color = new Color32(130, 130, 130, 255);
        else thisImg.color = new Color32(255, 255, 255, 255);

        ES.setTile(int.Parse(gameObject.name), isOn);
    }
}
