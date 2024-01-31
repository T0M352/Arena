using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightClass : PlayerOne
{

    private bool IsUlt;
    protected override void Update()
    {
        base.Update();

        if(gameObject.name == "Player1Knight")
        {
            if(GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.H) && ultTimer == 0)
                {
                    ultTimer = 100;
                    Instantiate(GameManager.instance.KnightUltPS, transform.position, transform.rotation, transform);
                    StartCoroutine(KnightUlt());
                }
            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    Instantiate(GameManager.instance.KnightUltPS, transform.position, transform.rotation, transform);
                    StartCoroutine(KnightUlt());
                }
            }
        }
        else if (gameObject.name == "Player2Knight")
        {
            if(GameManager.controlSettings == 0)
            {
                if (Input.GetKeyUp(KeyCode.Keypad3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    Instantiate(GameManager.instance.KnightUltPS, transform.position, transform.rotation, transform);
                    StartCoroutine(KnightUlt());
                }
            }
            else if(GameManager.controlSettings == 1)
            {

                if (Input.GetKeyUp(KeyCode.JoystickButton3) && ultTimer == 0) 
                {
                    ultTimer = 100;
                    Instantiate(GameManager.instance.KnightUltPS, transform.position, transform.rotation, transform);
                    StartCoroutine(KnightUlt());
                }
            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick2Button3) && ultTimer == 0)
                {
                    ultTimer = 100;
                    Instantiate(GameManager.instance.KnightUltPS, transform.position, transform.rotation, transform);
                    StartCoroutine(KnightUlt());
                }
            }
        }







        if (IsUlt == true)
            lastImmune = Time.time + 1f;

    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (moveDirectory == Vector3.zero)  
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);
    }

        IEnumerator KnightUlt()
    {
            IsUlt = true;
            yield return new WaitForSeconds(10f);
            IsUlt = false;

    }
}
