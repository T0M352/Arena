using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Destroyable : MonoBehaviour
{
    private float lastImmune;
    private float immuneTime = 0.5f;
    public float health = 5f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(health < 0)
        {
            animator.Play("barrel_destroy");
        }
    }
    protected virtual void ReciveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            GameManager.instance.ShowText(transform.position, dmg.damageAmount.ToString());
            health -= dmg.damageAmount;
        }
    }

    private void destroed()
    {
        Destroy(gameObject);
    }
}
