using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public AudioClip clipFireStandard;
    public AudioClip clipFireRocket;

    public AudioSource audioSource;
    // Start is called before the first frame update
    private Transform target;
    private Enemy targetEnemy;
    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets(default)")]
    [SerializeField] private GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public Light impactLight;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public int damageOverTime = 20;
    public float slowPercentage = 0.5f;

    [Header("Unity Setup Fields")]

    [SerializeField] private Transform firePoint;
    private string enemyTag = "Enemy";
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
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }
        TargetEnemy();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
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
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
    }
    void TargetEnemy()
    {
        Vector3 dir = target.position - transform.position - new Vector3(0, 2, 0);
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(partToRotate.transform.forward, dir, singleStep, 0.0f);
        partToRotate.transform.rotation = Quaternion.LookRotation(newDir);
    }
    void Shoot()
    {
        if (firePoint.childCount > 1)
        {
            audioSource.PlayOneShot(clipFireRocket);
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

                if (bullet.name == "Bullet(Clone)" || bullet.name == "Bullet_Upgraded(Clone)")
                    audioSource.PlayOneShot(clipFireStandard);

                if (bulletGO.name == "Missile(Clone)"|| bulletGO.name == "Missile_Upgraded(Clone)")
                    audioSource.PlayOneShot(clipFireRocket);

                bullet.Seek(target);
            }
        }

    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercentage);
        //GFX stuff
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }
    //Slowing Function  (used by turrets to reduce speed)

}
