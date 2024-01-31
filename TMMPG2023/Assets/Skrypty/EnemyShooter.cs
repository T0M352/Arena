using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float attackDist;
    [SerializeField]
    protected float backDist;
    [SerializeField]
    protected float defendDist;
    [SerializeField]
    protected float chaseDist;
    [SerializeField]
    protected float knockTime;
    [SerializeField]
    protected Transform startPos;

    [SerializeField]
    protected GameObject arrow;

    [SerializeField]
    protected Transform arrowStartPos;


    protected float immuneTime = 0.5f;
    protected float lastImmune;
    protected Transform target;
    protected Vector3 moveDirectory;
    protected bool isAttacking;
    protected bool goBack;
    protected Vector3 pushDirection;
    protected float pushForce;
    public Vector2 veelocity;
    private bool blocked;
    private List<GameObject> otherEnemies;



    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.Play("goblin_idle");

    }

    protected virtual void Update()
    {
        if (health < 1)
        {
            Death();

        }
    }

    protected virtual void FixedUpdate()
    {

        if (rb != null)
        {
            veelocity = rb.velocity;
            //WROG W ZASIEGU
            if (target != null)
            {
                float dist = Vector3.Distance(target.position, transform.position);


                if (blocked == false)
                {
                    if(dist <= chaseDist && dist > attackDist)
                    {
                        moveDirectory = (target.position - transform.position).normalized;
                        rb.velocity = moveDirectory * moveSpeed;
                    }
                    else if (dist <= attackDist && dist > backDist) 
                    {
                        moveDirectory = (target.position - transform.position).normalized;
                        Attack();
                        rb.velocity = Vector2.zero;
                        blocked = false;
                    }
                    else if (dist <= backDist && dist > defendDist)
                    {
                        animator.Play("goblin_walk");
                        moveDirectory = (transform.position - target.position).normalized;
                        rb.velocity = moveDirectory * moveSpeed;
                        if(blocked)
                        {
                            moveDirectory = (target.position - transform.position).normalized;
                            Attack();
                            rb.velocity = Vector2.zero;
                        }
                    }
                    else if (dist <= defendDist)
                    {
                        blocked = false;
                        moveDirectory = (target.position - transform.position).normalized;
                        Attack();
                        rb.velocity = Vector2.zero;
                    }
                    else
                        UnAttack();
                }

                if(blocked == true) 
                {
                    moveDirectory = (target.position - transform.position).normalized;
                    Attack();
                    rb.velocity = Vector2.zero;
                }
            }
            else if (target == null && health>0)
            {
                if (Vector3.Distance(startPos.position, transform.position) > 0.1)
                {
                    animator.Play("goblin_walk");
                    moveDirectory = (startPos.position - transform.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed;
                }
                else
                {
                    moveDirectory = Vector2.zero;
                    rb.velocity = Vector2.zero;
                    animator.Play("goblin_idle");
                }

            }



                if (moveDirectory.x > 0)  
                    transform.localScale = new Vector3(0.5f, 0.5f, 1);
                else if (moveDirectory.x < 0)
                    transform.localScale = new Vector3(-0.5f, 0.5f, 1);


   

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


        //
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            target = null;


    }
    private IEnumerator Knockback()
    {
        yield return new WaitForSeconds(knockTime);
        pushDirection = Vector2.zero;
        pushForce = 0;
    }

    protected virtual void switchToIdle()
    {
        animator.Play("goblin_idle");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (target != null)
        {
            blocked = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            blocked = false;
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
        animator.Play("goblin_attack");
    }

    protected virtual void UnAttack()
    {
        isAttacking = false;
    }

    private void shotArrow()
    {
        GameObject Arrow = Instantiate(arrow, arrowStartPos.position, arrowStartPos.rotation);
        Arrow.SendMessage("SetDir", moveDirectory);
        Arrow.SendMessage("Target", target);
    }




    protected virtual void Death()
    {
        Destroy(rb);
        target = null;
        animator.Play("goblin_death");
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
