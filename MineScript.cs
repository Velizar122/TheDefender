using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    private int Damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
            Enemy2 enemy2 = other.gameObject.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(Damage);
                Destroy(gameObject);
            }
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
                Destroy(gameObject);
            }
            Enemy3 enemy3 = other.gameObject.GetComponent<Enemy3>();
            if (enemy3 != null)
            {
                enemy3.TakeDamage(Damage);
                Destroy(gameObject);
        }
    }
}
