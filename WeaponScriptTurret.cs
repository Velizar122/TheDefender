using Pathfinding.Util;
using System.IO;
using UnityEngine;

public class WeaponScriptTurret : MonoBehaviour
{ 
    public Transform Target;
    public float range;
    public string enemyTag = "Enemy";
    public Transform partoToRotate;
    Rigidbody2D rb;
    public float speedRotation = 0.1f;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        rb = GetComponent<Rigidbody2D>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies=GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanse = Mathf.Infinity;
        GameObject nearestEnemy = null; 
        foreach (GameObject enemy in enemies)
        {
            float distanseToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanseToEnemy<shortestDistanse)
            {
                shortestDistanse = distanseToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy!=null && shortestDistanse <=range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target=null;
        }
    }
    void Update()
    { 
        if (Target==null) 
        {
            return; 
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
