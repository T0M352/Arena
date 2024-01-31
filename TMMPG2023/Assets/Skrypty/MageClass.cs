using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class MageClass : PlayerOne
{
    public float[] fireballSpeed = { 2.5f, -2.5f };
    public float distance = 0.25f;
    public GameObject[] mageUlt;
    public GameObject fireball;
    public Transform fireballStartPos;
    private bool throwFireball;
    public GameObject aimFireball;

    protected override void Start()
    {
        base.Start();
    }

    protected  override void Update()
    {
        base.Update();

        for (int i = 0; i < mageUlt.Length; i++)
            mageUlt[i].transform.position = transform.position + new Vector3(-Mathf.Cos(Time.time * fireballSpeed[i]) * distance, Mathf.Sin(Time.time * fireballSpeed[i]) * distance, 0);

        
        if(gameObject.name == "Player1Mage")
        {
            if(GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.H) && ultTimer == 0) 
                {
                    ultTimer = 100;
                    mageUlt[0].SetActive(true);
                    mageUlt[1].SetActive(true);
                    StartCoroutine(MageUlt());
                }
                if (Input.GetKeyUp(KeyCode.F)  && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) 
                {
                    throwFireball = true;
                    animator.Play("mage_attack");
                }

            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick1Button3) && ultTimer == 0) 
                {
                    ultTimer = 100;
                    mageUlt[0].SetActive(true);
                    mageUlt[1].SetActive(true);
                    StartCoroutine(MageUlt());
                }
                if (Input.GetKeyUp(KeyCode.Joystick1Button0) && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) 
                {
                    throwFireball = true;
                    animator.Play("mage_attack");
                }
            }
        }
        else if(gameObject.name == "Player2Mage")
        {
            if(GameManager.controlSettings == 0)
            {
                if (Input.GetKeyUp(KeyCode.Keypad3) && gameObject.name == "Player2Mage" && ultTimer == 0)
                {
                    ultTimer = 100;
                    mageUlt[0].SetActive(true);
                    mageUlt[1].SetActive(true);
                    StartCoroutine(MageUlt());
                }

                if (Input.GetKeyUp(KeyCode.Keypad1) && gameObject.name == "Player2Mage" && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) 
                {
                    throwFireball = true;
                    animator.Play("mage_attack");
                }
            }
            else if (GameManager.controlSettings == 1)
            {
                if (Input.GetKeyUp(KeyCode.JoystickButton3) && gameObject.name == "Player2Mage" && ultTimer == 0)
                {
                    ultTimer = 100;
                    mageUlt[0].SetActive(true);
                    mageUlt[1].SetActive(true);
                    StartCoroutine(MageUlt());
                }

                if (Input.GetKeyUp(KeyCode.JoystickButton0) && gameObject.name == "Player2Mage" && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) 
                {
                    throwFireball = true;
                    animator.Play("mage_attack");
                }
            }else if (GameManager.controlSettings == 2)
            {
                if (Input.GetKeyUp(KeyCode.Joystick2Button3) && gameObject.name == "Player2Mage" && ultTimer == 0)
                {
                    ultTimer = 100;
                    mageUlt[0].SetActive(true);
                    mageUlt[1].SetActive(true);
                    StartCoroutine(MageUlt());
                }

                if (Input.GetKeyUp(KeyCode.Joystick2Button0) && gameObject.name == "Player2Mage" && stamina > 10 && Time.time - lastAttack > cooldown && isAtacking == false) 
                {
                    throwFireball = true;
                    animator.Play("mage_attack");
                }
            }
        }
        




    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (throwFireball == true) { 

        GameManager.fireballDir = (aimFireball.transform.position - transform.position).normalized;
        aimFireball.SetActive(true);
        rb.velocity = Vector2.zero;
        aimFireball.GetComponent<Rigidbody2D>().velocity = moveDirectory * moveSpeed;
        }
        else
        {
            aimFireball.SetActive(false);
        }

        if (moveDirectory == Vector3.zero)  
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);
    }

    IEnumerator MageUlt()
    {
        yield return new WaitForSeconds(10f);
        mageUlt[0].SetActive(false);
        mageUlt[1].SetActive(false);
    }

    private void ThrowFireball()
    {
        throwFireball = false;
        Instantiate(fireball, fireballStartPos.position, fireballStartPos.rotation);
        aimFireball.GetComponent<Transform>().position = fireballStartPos.position;
    }

    private void switchToIdleMage()
    {
        animator.Play("mage_idle");
        isAtacking = false;
    }

    private void unDash()
    {
        animator.Play("mage_undash");
    }

    private void backToLayer()
    {
        if (gameObject.name == "Player1Mage")
        {
            int LayerMage = LayerMask.NameToLayer("mage1");
            gameObject.layer = LayerMage; 
        } else if (gameObject.name == "Player2Mage")
        {
            int LayerMage = LayerMask.NameToLayer("mage2");
            gameObject.layer = LayerMage;
        }
    }

    
}
