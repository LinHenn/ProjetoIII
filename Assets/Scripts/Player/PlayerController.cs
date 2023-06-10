using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController PC;

    public Material suitPlayer;

    public bool mayMove;
    [SerializeField] private float p_Speed;
    [SerializeField] private Transform cameraman;
    [SerializeField] private MouseLook m_MouseLook;

    private CharacterController m_CharacterController;


    private void Awake()
    {
        PC = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        m_CharacterController = GetComponent<CharacterController>();


        m_MouseLook.Init(transform, cameraman.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Gamecontrol.GC.isPause) return;

        RotateView();
        detection(mayMove);

        if (mayMove)
        {            
            SetMove();            
        }
    }


    private void detection(bool detect)
    {
        if(!detect)
        {
            Gamecontrol.GC.setTarget("", false);
            return;
        }

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraman.position,cameraman.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(cameraman.position, cameraman.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            //Debug.Log("Did Hit");

            /*
            IInteractible obj = hit.transform.GetComponent<IInteractible>();
            if (obj != null)
            {
                hit.transform.GetComponent<InfoBase>().GetName();

                if(mayMove) if (Input.GetAxis("Fire1") > 0) obj.Interaction();
            }
            */
            var obj = hit.transform.GetComponent<InfoBase>();
            if (obj != null)
            {
                obj.GetName();

                if (mayMove) if (Input.GetAxis("Fire1") > 0) obj.willInteract();
            }
            else Gamecontrol.GC.setTarget("", false);


        }
        else
        {
            Debug.DrawRay(cameraman.position, cameraman.TransformDirection(Vector3.forward) * 1000, Color.red);
            //Debug.Log("Did not Hit");
            Gamecontrol.GC.setTarget("", false);
        }


    }



    private void SetMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

               

        Vector2 m_Input = new Vector2(horizontal, vertical);
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        //Debug.Log(m_Input);

        Vector3 desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
        Vector3 m_MoveDir = Vector3.zero;

        m_MoveDir.x = desiredMove.x * p_Speed;
        m_MoveDir.z = desiredMove.z * p_Speed;

        if (m_CharacterController.isGrounded)
        {
            m_MoveDir.y = -10;
            //Debug.Log("isGrounded");
        }
        else
        {
            //Debug.Log("isflying");

            m_MoveDir += Physics.gravity * Time.fixedDeltaTime * 30;
        }

        m_CharacterController.Move(m_MoveDir * Time.deltaTime);

        m_MouseLook.UpdateCursorLock();

    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, cameraman.transform);
    }


    public void setMove(bool isAct)
    {
        mayMove = isAct;
    }


    public void slowMouse(bool i)
    {
        if (i)
        {
            m_MouseLook.XSensitivity = 0.5f;
            m_MouseLook.YSensitivity = 0.5f;
        }
        else
        {
            m_MouseLook.XSensitivity = 2f;
            m_MouseLook.YSensitivity = 2f;
        }

    }

    public Material changeSuit(Material mat)
    {
        var suit = suitPlayer;
        suitPlayer = mat;


        return suit;
    }


}
