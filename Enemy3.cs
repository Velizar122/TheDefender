using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public int Health = 1;
    public int Damage;
    public Animator animator;
    public bool Checker = false;
    public BoxCollider2D myGameObject;

    private float startTime;


    private void Awake()
    {
    }
    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= 2f)
        {
            AstarPath.active.Scan();
            startTime = Time.time;
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Scored3 scoreManager = FindObjectOfType<Scored3>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (Checker == false)
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            Earth earth = collision.gameObject.GetComponent<Earth>();
            if (player != null)
            {
                myGameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (earth != null)
            {
                earth.TakeDamage(Damage);
                TakeDamage(Damage);
                Checker = true;
            }
            Enemy2 enemy2 = collision.gameObject.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(Damage);
                TakeDamage(Damage);
                Checker = true;
            }
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
                TakeDamage(Damage);
                Checker = true;
            }
            Enemy3 enemy3 = collision.gameObject.GetComponent<Enemy3>();
            if (enemy3 != null)
            {
                enemy3.TakeDamage(Damage);
                TakeDamage(Damage);
                Checker = true;
            }
        }
    }
}
