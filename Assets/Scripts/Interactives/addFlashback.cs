using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFlashback : MonoBehaviour, IInteractible
{
    public Sprite img;

    public void Interaction()
    {
        flashback.instance.addPhoto(img);
    }


}
