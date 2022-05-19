using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTest : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float range = 15f;
    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Unity Setup Fields")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    public string enemyTag;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        TargetEnemy();
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

        /*Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation =  Quaternion.Euler(0f, rotation.y, 0f);
        */
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }
    void TargetEnemy()
    {
        Vector3 dir = target.position - transform.position;
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(partToRotate.transform.forward, dir, singleStep, 0.0f);
        partToRotate.transform.rotation = Quaternion.LookRotation(newDir);
    }
    void Shoot()
    {
        if (firePoint.childCount > 1)
        {
            for (int i = 0; i < firePoint.childCount; i++)
            {
                GameObject bulletsGO = (GameObject)Instantiate(bulletPrefab, firePoint.GetChild(i).position, firePoint.GetChild(i).rotation);
                Bullet bullets = bulletsGO.GetComponent<Bullet>();
                if (bullets != null)
                {
                    bullets.Seek(target);
                }
            }

        }
        else
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }

    }
}
