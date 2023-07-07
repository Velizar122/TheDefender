using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Enemy2 : MonoBehaviour
{
    public int Health = 1;
    [SerializeField] public float MoveSpeed = 0.001f;
    Rigidbody2D rb;
    Transform Target;
    Vector2 MoveDirection;
    public Transform Object;
    public int DamageOnCollide;
    public Animator animator;
    public bool Checker = false;
    public BoxCollider2D myGameObject;
    public float speed = 2f;
    public float radius ;
    private float angle;
    public float DefaultMoveSpeed;
    public Transform CenterPoint;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Target = GameObject.Find("Earth").transform;
        CenterPoint=GameObject.Find("CenterPoint").transform;
    }
    private void Update()
    {
        if (Target)
        {
            float distance = Vector3.Distance(Target.position, Object.position);
                Vector3 direction = (Target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                MoveDirection = direction;

                rb.velocity = MoveDirection * MoveSpeed;
                if (distance <= radius)
                {
                    MoveSpeed = 0f;
                    rb.velocity = MoveDirection * MoveSpeed;
            }
        }

        if (Target)
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = angle;
            transform.up = direction;
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
        Scored2 scoreManager2 = FindObjectOfType<Scored2>();
        if (scoreManager2 != null)
        {
            scoreManager2.AddScore(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
            myGameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (Checker==false)
            { 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(DamageOnCollide);
                TakeDamage(DamageOnCollide);
                Checker = true;
            }
            Enemy2 enemy2 = collision.gameObject.GetComponent<Enemy2>();
            if (enemy2 != null)
            {
                enemy2.TakeDamage(DamageOnCollide);
                TakeDamage(DamageOnCollide);
                Checker = true;
            }
            Enemy3 enemy3 = collision.gameObject.GetComponent<Enemy3>();
            if (enemy3 != null)
            {
                enemy3.TakeDamage(DamageOnCollide);
                TakeDamage(DamageOnCollide);
                Checker = true;
            }
        }
    }
}


