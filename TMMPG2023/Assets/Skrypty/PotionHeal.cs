using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHeal : MonoBehaviour
{
    public int healingAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player1Barb" || collision.transform.name == "Player1Knight" ||
            collision.transform.name == "Player1Thief" || collision.transform.name == "Player1Mage")
            GameManager.instance.player.Heal(healingAmount);
        else if (collision.transform.name == "Player2Barb" || collision.transform.name == "Player2Knight" ||
            collision.transform.name == "Player2Thief" || collision.transform.name == "Player2Mage")
            GameManager.instance.player2.Heal(healingAmount);

        Destroy(gameObject);

    }
}
