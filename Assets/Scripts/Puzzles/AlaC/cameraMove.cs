using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float sensibility = 2f;
    public float mouseX;

    public doorCamera DC;


    public float timer = 0.5f;

    [SerializeField]
    private bool isTalk = false; //True se estiver conversando
    private bool talked;

    [SerializeField]
    private CommumChat Prisioneer; //apenas para conversa atraves das grades



    public void setTalk(bool index) //Chama apenas para iniciar conversa
    {
        isTalk = index;
        if(!index) Prisioneer.mayChat = true;

    }



    private void Update()
    {
        float eixo = Input.GetAxis("Mouse X");


        mouseX += Input.GetAxis("Mouse X") * sensibility;

        if (mouseX < -30) mouseX = -30;
        if (mouseX > 30) mouseX = 30;

        transform.eulerAngles = new Vector3(0, mouseX, 0);


        if (isTalk) return;
        timer -= Time.deltaTime;


        if (timer > 0) return;


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DC.returnGame();
            timer = 0.5f;
        }
    }


}
