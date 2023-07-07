using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Earth earth = collision.gameObject.GetComponent<Earth>();
        if (earth != null)
        {
            // Deal damage to the enemy
            earth.TakeDamage(Damage);
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
