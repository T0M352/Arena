using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerOne : MonoBehaviour
{
    protected BoxCollider2D boxCollider;

    private bool isDashing;
    private bool isDashingP2;
    public bool canDash = false;
    protected Animator animator;
    public float maxStamina = 100;
    public float stamina = 100;
    public float StaminaIncreasePerFrame = 4.0f;
    public float ultTimer = 0;
    public float ultTimerPerFrame = 2f;
    protected float lastAttack; 
    protected float cooldown = 0.5f;


    public GameObject attackArea;


    protected bool isAtacking = false;

    protected Rigidbody2D rb;
    public Vector3 moveDirectory;
    public const float moveSpeed = 1f;

    
    public float knockTime = 0.2f;
    public float dashSpeed;
    public float dashTime;

    private float bonusSpeed;
    private int bonusMaxHitpoint;
    private float bonusStamina;

    private bool speedUpgrade = false;
    private bool hpUpgrade = false;
    private bool staminaUpgrade = false;

    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.2f;

    private float immuneTime = 0.5f;
    protected float lastImmune;

    protected Vector3 pushDirection;
    protected Vector2 pushDir;
    protected float PushForce;







    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
        bonusMaxHitpoint = Mathf.RoundToInt(maxHitPoint * 1.4f);
        bonusSpeed = moveSpeed * 1.4f;
        bonusStamina = maxStamina * 1.4f;

    }


    protected virtual void Update()
    {

        stamina = Mathf.Clamp(stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, maxStamina); 
        ultTimer = Mathf.Clamp(ultTimer - (ultTimerPerFrame * Time.deltaTime), 0.0f, 100);

        if (canDash == true && GameManager.dungeonMode != 2)
        {

            if (gameObject.name == "Player1Barb" || gameObject.name == "Player1Knight" || gameObject.name == "Player1Thief" || gameObject.name == "Player1Mage")  
            {
                if (GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
                {


                    if (Input.GetKeyUp(KeyCode.G) && isDashing == false && stamina > 20) 
                    {
                        isAtacking = true;

                        canDash = false;
                        stamina -= 20;
                        if (gameObject.name == "Player1Mage")
                            animator.Play("mage_dash");
                        else
                            isDashing = true;
                    }
                }
                else if(GameManager.controlSettings == 2)
                {
                    if (Input.GetKeyUp(KeyCode.Joystick1Button1) && isDashing == false && stamina > 20) 
                    {
                        isAtacking = true; 

                        canDash = false;
                        stamina -= 20;
                        if (gameObject.name == "Player1Mage")
                            animator.Play("mage_dash");
                        else
                            isDashing = true;
                    }
                }
            }


            if (gameObject.name == "Player2Barb" || gameObject.name == "Player2Knight" || gameObject.name == "Player2Thief" || gameObject.name == "Player2Mage")  
            {
                if (GameManager.controlSettings == 0)
                {
                    if (Input.GetKeyUp(KeyCode.Keypad2) && isDashingP2 == false && stamina > 20) 
                    {
                        isAtacking = true; //to tu

                        canDash = false;
                        stamina -= 20;
                        if (gameObject.name == "Player2Mage" && isDashingP2 == false)
                            animator.Play("mage_dash");
                        else
                            isDashingP2 = true;
                    }
                }else if (GameManager.controlSettings == 1)
                {
                    if (Input.GetKeyUp(KeyCode.JoystickButton1) && isDashingP2 == false && stamina > 20) 
                    {
                        isAtacking = true; //to tu
                        canDash = false;
                        stamina -= 20;
                        if (gameObject.name == "Player2Mage" && isDashingP2 == false)
                            animator.Play("mage_dash");
                        else
                            isDashingP2 = true;
                    }
                }else if (GameManager.controlSettings == 2)
                {
                    if (Input.GetKeyUp(KeyCode.Joystick2Button1) && isDashingP2 == false && stamina > 20) 
                    {
                        isAtacking = true; //to tu
                        canDash = false;
                        stamina -= 20;
                        if (gameObject.name == "Player2Mage" && isDashingP2 == false)
                            animator.Play("mage_dash");
                        else
                            isDashingP2 = true;
                    }
                }
            }
        }


        if(hpUpgrade == true)
        {
            maxHitPoint = bonusMaxHitpoint;
            hitPoint = maxHitPoint;
            hpUpgrade = false;
        }

        if(staminaUpgrade == true)
        {
            maxStamina = bonusStamina;
            staminaUpgrade = false;
        }


    }



    protected virtual void FixedUpdate()
    {
        if (GameManager.controlSettings == 0)
        {
            if (transform.name == "Player1Barb" || transform.name == "Player1Knight" || transform.name == "Player1Thief" || transform.name == "Player1Mage") 
            {
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                if (isDashing == false)
                    moveDirectory = new Vector3(x, y).normalized;
            }
            else if (transform.name == "Player2Barb" || transform.name == "Player2Knight" || transform.name == "Player2Thief" || transform.name == "Player2Mage") 
            {
                float x = Input.GetAxisRaw("Horizontal2");
                float y = Input.GetAxisRaw("Vertical2");
                if (isDashingP2 == false)
                    moveDirectory = new Vector3(x, y).normalized;
            }
        }
        else if (GameManager.controlSettings == 1)
        {
            if (transform.name == "Player1Barb" || transform.name == "Player1Knight" || transform.name == "Player1Thief" || transform.name == "Player1Mage") 
            {
                float x;
                float y;
                if (Input.GetKey(KeyCode.A))
                {
                    x = -1f;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    x = 1f;
                }
                else
                {
                    x = 0f;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    y = -1f;
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    y = 1f;
                }
                else
                {
                    y = 0f;
                }
                if (isDashing == false)
                    moveDirectory = new Vector3(x, y).normalized;
            }
            else if (transform.name == "Player2Barb" || transform.name == "Player2Knight" || transform.name == "Player2Thief" || transform.name == "Player2Mage") 
            {

                float x = Input.GetAxis("dpadX");
                float y = Input.GetAxis("dpadY");

                if (isDashingP2 == false)
                    moveDirectory = new Vector3(x, y).normalized;
            }
        }
        else if(GameManager.controlSettings == 2)
        {
            if (transform.name == "Player1Barb" || transform.name == "Player1Knight" || transform.name == "Player1Thief" || transform.name == "Player1Mage") 
            {

                float x = Input.GetAxis("dpadX");
                float y = Input.GetAxis("dpadY");


                if (isDashingP2 == false)
                    moveDirectory = new Vector3(x, y).normalized;

            }
            else if (transform.name == "Player2Barb" || transform.name == "Player2Knight" || transform.name == "Player2Thief" || transform.name == "Player2Mage") 
            {

                float x = Input.GetAxis("dpad2X");
                float y = Input.GetAxis("dpad2Y");


                if (isDashingP2 == false)
                    moveDirectory = new Vector3(x, y).normalized;
            }
        }
        
        if(speedUpgrade == false)
            rb.velocity = moveDirectory * moveSpeed;  
        else
            rb.velocity = moveDirectory * bonusSpeed; 

        if (moveDirectory.x > 0)  
        {
            if(gameObject.name == "Player1Mage" || gameObject.name == "Player2Mage")
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
            else
                transform.localScale = new Vector3(0.6f, 0.6f, 1);
        }

        else if (moveDirectory.x < 0)
        {
           if (gameObject.name == "Player1Mage" || gameObject.name == "Player2Mage")
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
           else
                transform.localScale = new Vector3(-0.6f, 0.6f, 1);

        }


        if (pushDirection != Vector3.zero) 
        {
            rb.AddForce(pushDirection * PushForce, ForceMode2D.Impulse);
            StartCoroutine(Knockback());
        }

        if(isDashing == true)
        {
            rb.AddForce(moveDirectory * dashSpeed, ForceMode2D.Impulse);
            StartCoroutine(dashP1());
        }

        if (isDashingP2 == true)
        {
            rb.AddForce(moveDirectory * dashSpeed, ForceMode2D.Impulse);
            StartCoroutine(dashP2());
        }

        if (GameManager.dungeonMode == 1) 
        {
            moveDirectory = Vector3.zero;
            rb.velocity = Vector3.zero;
        }

    }




    public void Heal(int healingAmount)
    {
        hitPoint += healingAmount;
        if (hitPoint > maxHitPoint)
            hitPoint = maxHitPoint;
        GameManager.instance.ShowText(transform.position, healingAmount.ToString());
        GameManager.instance.OnHitpointChange();
    }

    protected void ReciveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized;
            PushForce = dmg.pushForce;
            GameManager.instance.ShowText(transform.position, dmg.damageAmount.ToString());


            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
        GameManager.instance.OnHitpointChange();
    }

    protected void Death()
    {
        if (hpUpgrade == false) 
        {
            if (gameObject.name == "Player1Barb" && GameManager.PlayerOneLives > 0)
            {
                animator.Play("barb_death");
            }

            if (gameObject.name == "Player1Knight" && GameManager.PlayerOneLives > 0)
            {
                animator.Play("rycerz_death");

            }

            if (gameObject.name == "Player1Thief" && GameManager.PlayerOneLives > 0)
            {
                animator.Play("thief_death");
            }

            if (gameObject.name == "Player1Mage" && GameManager.PlayerOneLives > 0)
            {
                animator.Play("mage_death");

            }

            if (gameObject.name == "Player2Barb" && GameManager.PlayerTwoLives > 0)
            {
                animator.Play("barb2_death");

            }

            if (gameObject.name == "Player2Knight" && GameManager.PlayerTwoLives > 0)
            {
                animator.Play("rycerz2_death");
            }

            if (gameObject.name == "Player2Thief" && GameManager.PlayerTwoLives > 0)
            {
                animator.Play("thief2_death");

            }
            if (gameObject.name == "Player2Mage" && GameManager.PlayerOneLives > 0)
            {
                animator.Play("mage2_death");

            }
        }
        else
        {
            if (gameObject.name == "Player1Barb" && GameManager.PlayerOneLives > -1)
            {
                animator.Play("barb_death");
            }

            if (gameObject.name == "Player1Knight" && GameManager.PlayerOneLives > -1)
            {
                animator.Play("rycerz_death");

            }

            if (gameObject.name == "Player1Thief" && GameManager.PlayerOneLives > -1)
            {
                animator.Play("thief_death");
            }

            if (gameObject.name == "Player1Mage" && GameManager.PlayerOneLives > -1)
            {
                animator.Play("mage_death");

            }

            if (gameObject.name == "Player2Barb" && GameManager.PlayerTwoLives > -1)
            {
                animator.Play("barb2_death");

            }

            if (gameObject.name == "Player2Knight" && GameManager.PlayerTwoLives > -1)
            {
                animator.Play("rycerz2_death");
            }

            if (gameObject.name == "Player2Thief" && GameManager.PlayerTwoLives > -1)
            {
                animator.Play("thief2_death");

            }
            if (gameObject.name == "Player2Mage" && GameManager.PlayerOneLives > -1)
            {
                animator.Play("mage2_death");
            }
        }
    }



    private void isAttackingFalse()
    {
        isAtacking = false;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void repsawnP1()
    {
        GameManager.respawnPlayerOne = true;
    }
    
    private void respawnP2()
    {
        GameManager.respawnPlayerTwo = true;
    }


    private IEnumerator Knockback()
    {
        yield return new WaitForSeconds(knockTime);
        pushDirection = Vector2.zero;
        PushForce = 0;
    }

    private IEnumerator dashP1()
    {
        int Layer = LayerMask.NameToLayer("dashingLayer"); 
        gameObject.layer = Layer; 
        animator.SetBool("isDash", true);
        yield return new WaitForSeconds(dashTime);
        animator.SetBool("isDash", false); 
        int LayerPostac = LayerMask.NameToLayer("Postaæ");
        gameObject.layer = LayerPostac; 
        isDashing = false;
        canDash = true;

        isAtacking = false;
    }

    private IEnumerator dashP2()
    {
        int Layer = LayerMask.NameToLayer("dashingLayer");
        gameObject.layer = Layer; 
        animator.SetBool("isDash", true); 
        yield return new WaitForSeconds(dashTime);
        animator.SetBool("isDash", false); 
        int LayerPostac = LayerMask.NameToLayer("Postaæ");
        gameObject.layer = LayerPostac;
        isDashingP2 = false;
        canDash = true;

        isAtacking = false;
    }

    private void mageDash()
    {
        rb.AddForce(moveDirectory * dashSpeed, ForceMode2D.Force);
        int Layer = LayerMask.NameToLayer("dashingLayer");
        gameObject.layer = Layer;
    }

    private void isDashingFalse()
    {
        canDash = true;

    }

    protected void reciveUpgrade(int n)
    {
        if (n == 1)
            speedUpgrade = true;
        else if (n == 2)
            hpUpgrade = true;
        else if (n == 3)
            staminaUpgrade = true;
    }

}