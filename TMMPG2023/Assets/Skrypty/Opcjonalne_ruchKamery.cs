using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opcjonalne_ruchKamery : MonoBehaviour
{

    //public Transform gracz;
    private void LateUpdate()
    {

        if (GameManager.instance.player != null && GameManager.instance.player2 != null && transform != null)
        {
            if (gameObject.name == "Main Camera2")
            {
                transform.position = new Vector3(GameManager.posP2.x, GameManager.posP2.y, -10);
            }
            else if (gameObject.name == "Main Cameraa")
            {
                transform.position = new Vector3(GameManager.posP1.x, GameManager.posP1.y, -10);
            }
        }
    }
}
