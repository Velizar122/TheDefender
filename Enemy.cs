using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Health = 1;
    public Animator animator;
    public bool Checker = false;
    public BoxCollider2D myGameObject;
    [SerializeField] public float MoveSpeed=0.001f;
    public int Damage;


    Rigidbody2D rb;
    Transform Target;
    Vector2 MoveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Target =GameObject.Find("Earth").transform;
    }
    private void Update()
    {
        if (Target)
        {
            Vector3 direction=(Target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.y)*Mathf.Rad2Deg;
            rb.rotation = angle;
            transform.up = direction;
            MoveDirection = direction;
        }
    }
    private void FixedUpdate()
    {
        if (Target)
        { 
            rb.velocity=new Vector2(MoveDirection.x, MoveDirection.y)*MoveSpeed;
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            animator.SetTrigger("Death");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Scored scoreManager = FindObjectOfType<Scored>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(1); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Checker == false)
        {
            PlayerMovement player=collision.gameObject.GetComponent<PlayerMovement>();
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
