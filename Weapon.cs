using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public Transform Object;
    Transform Target;

    private void Start()
    {
        Target = GameObject.Find("Earth").transform;
        StartCoroutine(FireBulletCoroutine());
    }

    private IEnumerator FireBulletCoroutine()
    {
        while (true)
        {
            float distance = Vector3.Distance(Target.position, Object.position);
            if (distance <= 1.5f)
            {
                Vector3 direction = (Target.position - bulletSpawnPoint.position).normalized;

                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }

            yield return new WaitForSeconds(5f);
        }
    }

}
