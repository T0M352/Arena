using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPostDung : MonoBehaviour
{
    private int numberOfPlayers = 0;

    private void Update()
    {
        if(numberOfPlayers == 2)
        {
            GameManager.dungeonMode = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            numberOfPlayers++;
    }
}
