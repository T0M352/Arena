using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOgre : Enemy
{

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (rb != null)
        {
            if (goBack == false)
            {
                if (moveDirectory.x > 0) 
                    transform.localScale = new Vector3(-0.6f, 0.6f, 1);
                else if (moveDirectory.x < 0)
                    transform.localScale = new Vector3(0.6f, 0.6f, 1);
            }
        }
    }

    protected override void afterDeath()
    {
        Destroy(rb);
        animator.Play("ogre_corpse");
    }
    protected override void Start()
    {
        base.Start();
        animator.Play("ogre_idle");
    }

    protected override void switchToIdle()
    {
        animator.Play("ogre_idle");
    }

    protected override void Attack()
    {
        base.Attack();
        animator.Play("ogre_attack");
    }

    protected override void UnAttack()
    {
        base.UnAttack();
        animator.Play("ogre_idle");

    }

    protected override void Death()
    {
        base.Death();
        animator.Play("ogre_death");
    }

    protected override void defAnimation()
    {
        animator.Play("ogre_idle");
    }
}
