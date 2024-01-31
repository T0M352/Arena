using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    private Rigidbody2D rb;
    Animator animator;
    public float fireballLifeSpan;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.name = "ULT";
        StartCoroutine(FireballAutoDestroy());
    } 

    private void FixedUpdate()
    {
        if(rb!= null)
        rb.AddForce(GameManager.fireballDir * fireballSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        animator.Play("fireball_end");
        
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
    private void DestroyRB()
    {
        Destroy(rb);
    }
    private IEnumerator FireballAutoDestroy()
    {
        yield return new WaitForSeconds(fireballLifeSpan);
        Destroy(gameObject);
    }
}
