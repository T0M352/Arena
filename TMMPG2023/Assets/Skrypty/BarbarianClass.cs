using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarbarianClass : PlayerOne
{
    public GameObject ultBarbOb;
    public GameObject legs;
    private Animator legAnimator;

    protected override void Start()
    {
        base.Start();
        legAnimator = legs.GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(gameObject.name == "Player1Barb")
        {
            if(GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.F) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false)
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("barb_attack");
                }

                if (Input.GetKeyUp(KeyCode.H) && gameObject.name == "Player1Barb" && ultTimer == 0)
                {
                    ultTimer = 100;
                    animator.Play("barb_ult");
                }

            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button0) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false)
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("barb_attack");
                }

                if (Input.GetKeyUp(KeyCode.Joystick1Button3) && gameObject.name == "Player1Barb" && ultTimer == 0)
                {
                    ultTimer = 100;
                    animator.Play("barb_ult");
                }
            }


        }
        else if (gameObject.name == "Player2Barb")
        {
            if (GameManager.controlSettings == 0)
            {

                if (Input.GetKeyUp(KeyCode.Keypad1) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) //Input.GetKeyUp(KeyCode.JoystickButton0)
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("barb_attack");
                }


                if (Input.GetKeyUp(KeyCode.Keypad3) && gameObject.name == "Player2Barb" && ultTimer == 0) //Input.GetKeyUp(KeyCode.JoystickButton3)
                {
                    ultTimer = 100;
                    animator.Play("barb_ult");

                }
            }
            else if(GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.JoystickButton0) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false && gameObject.name == "Player2Barb") //Input.GetKeyUp(KeyCode.JoystickButton0)
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("barb_attack");
                }


                if (Input.GetKeyUp(KeyCode.JoystickButton3) && gameObject.name == "Player2Barb" && ultTimer == 0) //Input.GetKeyUp(KeyCode.JoystickButton3)
                {
                    ultTimer = 100;
                    animator.Play("barb_ult");

                }
            }else if(GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick2Button0) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false && gameObject.name == "Player2Barb") //Input.GetKeyUp(KeyCode.JoystickButton0)
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("barb_attack");
                }


                if (Input.GetKeyUp(KeyCode.Joystick2Button3) && gameObject.name == "Player2Barb" && ultTimer == 0) //Input.GetKeyUp(KeyCode.JoystickButton3)
                {
                    ultTimer = 100;
                    animator.Play("barb_ult");

                }
            }
        }

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (moveDirectory == Vector3.zero)  
            legAnimator.SetBool("isMoving", false);
        else
            legAnimator.SetBool("isMoving", true);
    }

    private void switchToIdle()
    {
        animator.Play("barb_idle");
    }

    private void enableBarbUlt()
    {
        ultBarbOb.GetComponent<BoxCollider2D>().enabled = true;

    }

    private void disableBarbUlt()
    {
        ultBarbOb.GetComponent<BoxCollider2D>().enabled = false;

    }

    private void enableBarbAttack()
    {
        attackArea.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void disableBarbAttack()
    {
        attackArea.GetComponent<BoxCollider2D>().enabled = false;
    }
}
