using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float fireballSpeed;
    public float arrowLifeSpan;
    private Rigidbody2D rb;
    private Vector3 arrowDirection;
    Transform target;
    BoxCollider2D boxCollider2D;
    public float destroyTime = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.name = "ULT";
        StartCoroutine(FireballAutoDestroy());
        transform.right = target.position - transform.position;
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    } 

    private void Update()
    {

            
    }
    private void FixedUpdate()
    {


        if (rb != null)
            rb.AddForce(arrowDirection * fireballSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(rb);
        boxCollider2D.enabled = false;
        if (collision.gameObject.tag == "Player")
            transform.SetParent(collision.transform);
        StartCoroutine(delayedDestroy());

    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }

    private IEnumerator FireballAutoDestroy()
    {
        yield return new WaitForSeconds(arrowLifeSpan);
        Destroy(gameObject);
    }

    public void SetDir(Vector3 direction)
    {
        arrowDirection = direction;
    }

    public void Target(Transform player)
    {
        target = player;
    }

    private IEnumerator delayedDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
