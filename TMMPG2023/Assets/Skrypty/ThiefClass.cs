using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefClass : PlayerOne
{

    public GameObject ultArea;
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

        if(gameObject.name == "Player1Thief")
        {
            if(GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.F)  && stamina > 10 && isAtacking == false)         
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("thief_attack");
                }
                 
                if (Input.GetKeyUp(KeyCode.H)  && ultTimer == 0)          
                {
                    ultTimer = 100;
                    isAtacking = true;
                    StartCoroutine(ThiefUlt());
                }
            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button0) && stamina > 10 && isAtacking == false)         
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
                    animator.Play("thief_attack");
                }

                if (Input.GetKeyUp(KeyCode.Joystick1Button3) && ultTimer == 0)         
                {
                    ultTimer = 100;
                    isAtacking = true;
                    StartCoroutine(ThiefUlt());
                }
            }
        }
        else if (gameObject.name == "Player2Thief")
        {
            if(GameManager.controlSettings == 0)
            {
                if (Input.GetKeyUp(KeyCode.Keypad1) && stamina > 10 && isAtacking == false) 
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
           
                    animator.Play("thief_attack");
                }


                if (Input.GetKeyUp(KeyCode.Keypad3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    isAtacking = true;
                    StartCoroutine(ThiefUlt());
                }
            }
            else if(GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.JoystickButton0) && stamina > 10 && isAtacking == false) 
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
            
                    animator.Play("thief_attack");
                }


                if (Input.GetKeyUp(KeyCode.JoystickButton3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    isAtacking = true;
                    StartCoroutine(ThiefUlt());
                }
            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick2Button0) && stamina > 10 && isAtacking == false) 
                {
                    isAtacking = true;
                    stamina -= 10;
                    lastAttack = Time.time;
   
                    animator.Play("thief_attack");
                }


                if (Input.GetKeyUp(KeyCode.Joystick2Button3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    isAtacking = true;
                    StartCoroutine(ThiefUlt());
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



        private void enableThiefAttack()
    {
            attackArea.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void disableThiefAttack()
    {
        attackArea.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void enableThiefUlt()
    {
        ultArea.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void disableThiefUlt()
    {
        ultArea.GetComponent<BoxCollider2D>().enabled = false;
    }


    IEnumerator ThiefUlt()
    {
        animator.Play("thief_ult");
        yield return new WaitForSeconds(2.0f);
        animator.Play("thief_idle");
        isAtacking = false;
    }

    private void switchToIdleThief()
    {
        animator.Play("thief_idle");
    }

}
