using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    /*=======================Dash============================= */

    //Dash direction
    Vector3 dashDir = Vector3.zero;

    //longueur du dash 
    [SerializeField]
    [Range(1f, 5000f)] public float dashLong = 1000;


    //Dash timer
    [SerializeField]
    [Range(0.01f, 30f)] public float dashTimer = 5f;
    public float dashCooler = 2f;

    //true if player is dashing
    public bool canDash = false;
    CharacterController cc;

    public int nbrDashInAir = 1;
    int countNbrDashInAir = 0;

    private void Start()
    {
        //init dashTimer
        dashTimer = 0.3f;
        dashCooler = dashTimer;
        cc = GetComponent<CharacterController>();

    }

    private void Update()
    {
        //Si le perso touche le sol, on, met la variable remet le nbr de jumps acutuel a 0
        if (cc.isGrounded)
            countNbrDashInAir = 0;
    }

    private void FixedUpdate()
    {

        Comp_Dash();      
       
    }

    void Comp_Dash()
    {
        if (!canDash)
        {
            dashCooler -= Time.deltaTime;
            if (dashCooler <= 0)
            {
             
                dashCooler = 0;
            }
        }


        if (Input.GetButton("Dash"))
        {

            if (canDash)
            {
                if (cc.isGrounded)
                {
                    canDash = false;
                    dashDir = transform.TransformDirection(Vector3.forward);
                    dashDir *= dashLong;
                    cc.Move(dashDir * Time.deltaTime);
                }
                else
                {
                    if (countNbrDashInAir < nbrDashInAir)
                    {
                        canDash = false;
                        dashDir = transform.TransformDirection(Vector3.forward);
                        dashDir *= dashLong;
                        cc.Move(dashDir * Time.deltaTime);
                        countNbrDashInAir++;
                    }
                }
            }
        }
        else
        {
            if (dashCooler <= 0)
            {
                canDash = true;
                dashCooler = dashTimer;
                 
            }
        }
    }
    void ResetDashTimer()
{

    if (dashCooler <= 0f)
    {
        canDash = true;

    }

}
}
