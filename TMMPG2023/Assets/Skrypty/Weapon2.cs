using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{

    public int damagePoint = 1;
    public float pushForce = 2.0f;



    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;



    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (GameManager.controlSettings == 0)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1) && GameManager.instance.player2.stamina > 10) 
            {
                if (Time.time - lastSwing > cooldown)
                {
                    lastSwing = Time.time;
                    if (gameObject.name == "miecz_01")
                        Swing();
                }
            }
        }
        else if(GameManager.controlSettings == 1)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton0) && GameManager.instance.player2.stamina > 10) 
            {
                if (Time.time - lastSwing > cooldown)
                {
                    lastSwing = Time.time;
                    if (gameObject.name == "miecz_01")
                        Swing();
                }
            }
        }
        else if (GameManager.controlSettings == 2)
        {
            if (Input.GetKeyUp(KeyCode.Joystick2Button0) && GameManager.instance.player2.stamina > 10) // klawisz ataku
            {
                if (Time.time - lastSwing > cooldown)
                {
                    lastSwing = Time.time;
                    if (gameObject.name == "miecz_01")
                        Swing();
                }
            }
        }
    }

    private void Swing()
    {
        GameManager.instance.player2.stamina -= 10;
        anim.SetTrigger("Swing");
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fighter" || collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player2Barb" || collision.gameObject.name == "Player2Knight" || collision.gameObject.name == "Player2Thief" || collision.gameObject.name == "Player2Mage")
                return;
            Damage dmg = new Damage();
            dmg.damageAmount = damagePoint;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            collision.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }

}
