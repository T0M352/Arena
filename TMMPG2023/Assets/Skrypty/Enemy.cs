using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    [SerializeField]
    protected GameObject attackArea;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float attackDist;
    [SerializeField]
    protected float backDist;
    [SerializeField]
    protected float knockTime;
    public float readyDist;
    [SerializeField]
    protected Transform startPos;

    protected float immuneTime = 0.5f;
    protected float lastImmune;
    protected Transform target;
    public Vector2 moveDirectory; 
    protected bool isAttacking;
    protected bool goBack;
    protected Vector3 pushDirection;
    protected float pushForce;

    protected Transform otherEnemy;

    public GameObject legs;
    protected Animator legAnimator;
    protected bool isDead = false;

    public GameObject diamond;





    protected bool defMode;
    protected bool oddalanie; 

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        legAnimator = legs.GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (health < 0 && isDead == false)
        {

            Death();    
        }

        if(isAttacking == false)
            attackArea.GetComponent<BoxCollider2D>().enabled = false;

    }

    protected virtual void FixedUpdate()
    {
        if (rb != null && isDead == false)

        {
           
            if (target != null)
            {
                float dist = Vector3.Distance(target.position, transform.position);
                if (goBack == false && dist > readyDist && isAttacking == false)
                {
                    moveDirectory = (target.position - transform.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed;
                }


                if (dist < readyDist && dist > attackDist && isAttacking == false)
                {
                    moveDirectory = (target.position - transform.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed / 2;
                    if (gameObject.name == "goblin")
                        defAnimation();
                }else if (dist < attackDist)
                    Attack();
                else
                    UnAttack();


                if (goBack == true)
                {
                    moveDirectory = (transform.position - target.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed / 2;
                    if (dist > backDist)
                    {
                        moveDirectory = Vector3.zero;
                        goBack = false;
                    }
                }

            }
            else if(target == null)
            {
                if (Vector3.Distance(startPos.position, transform.position) > 0.1)
                {
                    moveDirectory = (startPos.position - transform.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed;
                }
                else
                {
                    moveDirectory = Vector2.zero;
                    rb.velocity = Vector2.zero;
                }
            }

            if (rb.velocity == Vector2.zero)  
                legAnimator.SetBool("isMoving", false);
            else
                legAnimator.SetBool("isMoving", true);

            if (pushDirection != Vector3.zero)  
            {
                rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                StartCoroutine(Knockback());
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            target = collision.transform;

        if (collision.tag == "Dead") 
            otherEnemy = collision.transform;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            target = null;

        if (collision.tag == "Dead") 
            otherEnemy = null;

    }
    protected IEnumerator Knockback()
    {
        yield return new WaitForSeconds(knockTime);
        pushDirection = Vector2.zero;
        pushForce = 0;
    }

    protected virtual void switchToIdle()
    {
    }

    protected virtual void enableAttack()
    {
        
        attackArea.GetComponent<BoxCollider2D>().enabled = true;
    }

    protected virtual void disableAttack()
    {
        attackArea.GetComponent<BoxCollider2D>().enabled = false;
        goBack = true;
    }

    protected virtual void ReciveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            pushDirection = (transform.position - target.transform.position).normalized;
            pushForce = dmg.pushForce;
            GameManager.instance.ShowText(transform.position, dmg.damageAmount.ToString());
            health -= dmg.damageAmount;
        }
    }

    protected virtual void Attack()
    {

        isAttacking = true;
    }

    protected virtual void UnAttack()
    {
        isAttacking = false;
    }




    protected virtual void Death()
    {
        var diam = Instantiate(diamond, transform.position, Quaternion.identity);
        diam.SendMessage("reciveMessage");
        isDead = true;
        target = null;
        gameObject.tag = "Dead";
        Destroy(legs);
        Destroy(rb);
    }

    protected virtual void afterDeath()
    {
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    protected virtual void defAnimation()
    {
        
    }
}
