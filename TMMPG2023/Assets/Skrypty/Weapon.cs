using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
        if (GameManager.controlSettings == 0 || GameManager.controlSettings == 1)
        {
            if (Input.GetKeyUp(KeyCode.F)  && GameManager.instance.player.stamina > 10 && Time.time - lastSwing > cooldown) 
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
            if (Input.GetKeyUp(KeyCode.Joystick1Button0) && GameManager.instance.player.stamina > 10 && Time.time - lastSwing > cooldown) 
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

    public void Swing()
    {
        GameManager.instance.player.stamina -= 10;  
        anim.SetTrigger("Swing");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fighter" || collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player1Barb" || collision.gameObject.name == "Player1Knight" || collision.gameObject.name == "Player1Thief" || collision.gameObject.name == "Player1Mage")
                return;
            Damage dmg = new Damage();
            dmg.damageAmount = damagePoint;
            dmg.origin = transform.position;
            dmg.pushForce = pushForce;

            collision.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }

}
