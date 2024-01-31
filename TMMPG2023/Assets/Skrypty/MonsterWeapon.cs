using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeapon : MonoBehaviour
{
    public int Damage; 
    public float Push;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage dmg = new Damage();
            dmg.damageAmount = Damage;
            dmg.origin = transform.position;
            dmg.pushForce = Push;
            collision.gameObject.SendMessage("ReciveDamage", dmg);
        }
    }
}
