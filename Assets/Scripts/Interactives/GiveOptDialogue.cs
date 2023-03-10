using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveOptDialogue : MonoBehaviour, IInteractible
{
    public List<OptionsDial> giveOptions;

    public void Interaction()
    {

        DialogueOptions.DO.setOptions(giveOptions);

        DialogueOptions.DO.showMouse(true);

    }


   


}
