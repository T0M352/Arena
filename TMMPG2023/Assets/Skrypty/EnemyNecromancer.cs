using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNecromancer : Enemy
{
    [SerializeField]
    GameObject skeleton;
    [SerializeField]
    GameObject summonPS;


    private void summonSkeleton()
    {
        Instantiate(summonPS, otherEnemy.position, Quaternion.identity);
        var Skeleton = Instantiate(skeleton, otherEnemy.position, Quaternion.identity);
        Destroy(otherEnemy.gameObject);
        otherEnemy = null;
    }
    protected override void FixedUpdate()
    {
        if (rb != null && isDead == false) 

        {

            if (target != null)
            {
                if (otherEnemy != null)
                {
                    animator.Play("necromancer_summon");
                }


                float dist = Vector3.Distance(target.position, transform.position);
                if (goBack == false && dist > readyDist && isAttacking == false)
                {
                    moveDirectory = (target.position - transform.position).normalized;
                    rb.velocity = moveDirectory * moveSpeed;
                }

                if (otherEnemy == null)
                {
                    if (dist < readyDist && dist > attackDist && isAttacking == false)
                    {
                        moveDirectory = (target.position - transform.position).normalized;
                        rb.velocity = Vector2.zero;
                    }
                    else if (dist < attackDist)
                        Attack();
                }


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

                if (goBack == false)
                {
                    if (moveDirectory.x > 0)  
                        transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    else if (moveDirectory.x < 0)
                        transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                }
            }
            else if (target == null)
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


            if (pushDirection != Vector3.zero) 
            {
                rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                StartCoroutine(Knockback());
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
            target = other.gameObject.transform;

    }

    protected override void Start()
    {
        base.Start();
        animator.Play("necromancer_idle");
    }

    protected override void switchToIdle()
    {
        animator.Play("necromancer_idle");
    }

    protected override void Attack()
    {
        base.Attack();
        animator.Play("necromancer_sword");
    }

    protected override void UnAttack()
    {
        base.UnAttack();
        animator.Play("necromancer_idle");

    }

    protected override void Death()
    {
        base.Death();
        animator.Play("necromancer_death");
    }

    protected override void defAnimation()
    {
        animator.Play("necromancer_idle");
    }
}
