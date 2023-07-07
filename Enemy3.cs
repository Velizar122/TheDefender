using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public int Health = 1;
    //[SerializeField] public float MoveSpeed = 0.001f;
    public int Damage;
   // Rigidbody2D rb;
    //Transform Target;
    //Vector2 MoveDirection;
    public Animator animator;
    public bool Checker = false;
    public BoxCollider2D myGameObject;
    private float startTime;
    //public float Speed = 0.1f;
    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        startTime = Time.time;
        //Target = GameObject.Find("Earth").transform;
    }
    //private void Update()
    //{
    //    //float distance = Vector3.Distance(Target.position, transform.position);
    //    //if (Target)
    //    //{

    //    //    Vector3 direction = (Target.position - transform.position).normalized;
    //    //    float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    //    //    rb.rotation = angle;
    //    //    transform.up = direction;
    //    //    MoveDirection = direction;
    //    //    //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Rayrange, obstacleLayer);
    //    //    //Debug.DrawRay(transform.position, direction,Color.green);
    //    //    //if (hit.collider != null)
    //    //    //{
    //    //    //    Debug.Log("daaaa");
    //    //    //    transform.Translate(Vector3.left *Speed* Time.deltaTime);
    //    //    //}
    //    //    //else
    //    //    //{
    //    //    //    Debug.Log("No obstacles detected");
    //    //    //}
    //    //    //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f);
    //    //    //Debug.DrawRay(transform.position, direction, Color.green);
    //    //    //if (hit.collider != null && CompareTag("Enemy"));
    //    //    //{
    //    //    //    Debug.Log("SSSSSSS");
    //    //    //    transform.Translate(Vector3.left * Time.deltaTime);
    //    //    //}
    //    //}

    //}
    //private void FixedUpdate()
    //{
    //    if (Target)
    //    {
    //        rb.velocity = new Vector2(MoveDirection.x, MoveDirection.y) * MoveSpeed;
    //    }
    //}
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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //    Enemy2 enemy2 = collision.gameObject.GetComponent<Enemy2>();
    //        if (enemy | enemy2 != null)
    //        {
    //            MoveSpeed = 0.1f;
    //            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    //        }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //    Enemy2 enemy2 = collision.gameObject.GetComponent<Enemy2>();
    //    if (enemy | enemy2 != null)
    //    {
    //        MoveSpeed = 0.1f;
    //        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    MoveSpeed = 0.5f;
    //}

}
