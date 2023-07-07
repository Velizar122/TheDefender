using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float radius = 2f;
    private float angle = 0f; 
    public int damage = 10;
    void Update()
    {

        if(Time.timeScale >= 1f)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                angle += touch.deltaPosition.x * speed;
            }
        }
        else
        {
            
        }

        Vector3 newPosition = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);
        Vector3 normal = new Vector3(-newPosition.x, 0f, -newPosition.z).normalized;
        transform.position = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Enemy2 enemy2 = collision.gameObject.GetComponent<Enemy2>();
        Enemy3 enemy3= collision.gameObject.GetComponent<Enemy3>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }
        if (enemy3!=null)
        {
            enemy3.TakeDamage(damage);
        }
    }
}
