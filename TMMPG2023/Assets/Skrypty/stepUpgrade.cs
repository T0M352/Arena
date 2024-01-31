using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepUpgrade : MonoBehaviour
{
    private bool stepped = false;
    public Sprite steppedSpirte;
    private SpriteRenderer stepRenderer;

    private void Start()
    {
        stepRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(stepped == false)
        {
            if (collision.transform.name == "Player1Barb" || collision.transform.name == "Player1Knight" ||
               collision.transform.name == "Player1Thief" || collision.transform.name == "Player1Mage")
            {
                if (gameObject.name == "stepArmor" && GameManager.diamondsP1 > 2)
                {
                    GameManager.diamondsP1 -= 3;
                    collision.SendMessage("reciveUpgrade", 2);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }
                else if (gameObject.name == "stepSpeed" && GameManager.diamondsP1 > 2)
                {
                    GameManager.diamondsP1 -= 3;
                    collision.SendMessage("reciveUpgrade", 1);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }
                else if (gameObject.name == "stepAttack" && GameManager.diamondsP1 > 2)
                {
                    GameManager.diamondsP1 -= 3;
                    collision.SendMessage("reciveUpgrade", 3);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }
            }

            else if (collision.transform.name == "Player2Barb" || collision.transform.name == "Player2Knight" ||
                collision.transform.name == "Player2Thief" || collision.transform.name == "Player2Mage")
            {
                if (gameObject.name == "stepArmor" && GameManager.diamondsP2 > 2)
                {
                    GameManager.diamondsP2 -= 3;
                    collision.SendMessage("reciveUpgrade", 2);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }
                else if (gameObject.name == "stepSpeed" && GameManager.diamondsP2 > 2)
                {
                    GameManager.diamondsP2 -= 3;
                    collision.SendMessage("reciveUpgrade", 1);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }
                else if (gameObject.name == "stepAttack" && GameManager.diamondsP2 > 2)
                {
                    GameManager.diamondsP2 -= 3;
                    collision.SendMessage("reciveUpgrade", 3);
                    stepRenderer.sprite = steppedSpirte;
                    stepped = true;
                }

            }

        }
    }


}
