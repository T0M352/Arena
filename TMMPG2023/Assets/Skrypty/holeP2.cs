using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeP2 : MonoBehaviour
{
    public GameObject teleportLocation;

    private void Start()
    {
        teleportLocation = GameObject.Find("teleportLocationP2");
    }
    public void Destroy()
    {
   
        Destroy(gameObject);
    }

    public void turnOnBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == GameManager.transformP2.name)
        collision.gameObject.GetComponent<Rigidbody2D>().position = teleportLocation.transform.position;
    }
}
