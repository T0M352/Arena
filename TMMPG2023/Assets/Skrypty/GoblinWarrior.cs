using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWarrior : Enemy
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (rb != null)
        {
            if (goBack == false)
            {
                if (moveDirectory.x > 0)  
                    transform.localScale = new Vector3(0.5f, 0.5f, 1);
                else if (moveDirectory.x < 0)
                    transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
        }
    }
    protected override void Start()
    {
        base.Start();
        animator.Play("goblin_idle");
    }
    protected override void afterDeath()
    {
        animator.Play("goblin_corpse");
    }

    protected override void switchToIdle()
    {
        animator.Play("goblin_idle");
    }

    protected override void Attack()
    {
        base.Attack();
        animator.Play("goblin_attack");
    }

    protected override void UnAttack()
    {
        base.UnAttack();
        animator.Play("goblin_walk");

    }

    protected override void Death()
    {
        base.Death();
        animator.Play("goblin_death");
    }



    protected override void defAnimation()
    {
        animator.Play("goblin_walk_def");
    }
}
