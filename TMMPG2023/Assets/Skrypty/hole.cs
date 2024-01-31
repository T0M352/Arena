using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public GameObject screenDarker;
    public GameObject teleportLocation;

    private void Start()
    {
        screenDarker = GameObject.Find("Fader");
        teleportLocation = GameObject.Find("teleportLocationP1");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void turnOnBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void DarkScreen()
    {
        screenDarker.gameObject.GetComponent<Animator>().Play("teleport");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == GameManager.transformP1.name)
            collision.gameObject.GetComponent<Rigidbody2D>().position = teleportLocation.transform.position;
    }

    public void splitCamera()
    {
        GameManager.dungeonMode = 2;
    }

}
