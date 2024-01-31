using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamontCollect : MonoBehaviour
{
    public Vector3 moveDirectory;
    private const float moveSpeed = 0.7f;
    private Rigidbody2D rb;
    private Transform target;
    private bool dropped = true;
    private Vector3 dropPosition;
    private float startSpeed;
    private bool immune = false;

    private void Start()
    {
        StartCoroutine(startImmune());
        startSpeed = moveSpeed * 3;
        int los = Random.Range(1, 3);
        if (los == 1)
            dropPosition = transform.position - new Vector3(Random.Range(0.0f, 0.3f), Random.Range(0.0f, 0.3f), 0);
        else
            dropPosition = transform.position + new Vector3(Random.Range(0.0f, 0.3f), Random.Range(0.0f, 0.3f), 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (immune == false)
        {
            if (collision.transform.name == "Player1Barb" || collision.transform.name == "Player1Knight" ||
                collision.transform.name == "Player1Thief" || collision.transform.name == "Player1Mage")
            {
                GameManager.diamondsP1++;
                Destroy(gameObject);
            }

            else if (collision.transform.name == "Player2Barb" || collision.transform.name == "Player2Knight" ||
                collision.transform.name == "Player2Thief" || collision.transform.name == "Player2Mage")
            {
                GameManager.diamondsP2++;
                Destroy(gameObject);
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && immune == false)
            target = collision.transform;
    }

    private void reciveMessage()
    {
        dropped = false;
    }



    private void FixedUpdate()
    {
        if (target != null)
        {
            moveDirectory = (target.position - transform.position).normalized;
            rb.velocity = moveDirectory * moveSpeed;
        }

        if (dropped == false)
        {
            moveDirectory = (dropPosition - transform.position).normalized;
            rb.velocity = moveDirectory * startSpeed;
            float distance = Vector3.Distance(transform.position, dropPosition);
            if (distance < 0.1f)
                dropped = true;
        }




    }

    private IEnumerator startImmune()
    {
        immune = true;
        yield return new WaitForSeconds(2f);
        immune = false;
    }
}