using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health;
    public int startHealth;
    public int worth;
    public float startSpeed = 10f;
    public Image healthBar;

    public float speed;
    private EnemyMovement em;
    private bool isDead = false;





    [SerializeField] private ParticleSystem ps;

    //public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<EnemyMovement>();
        speed = startSpeed;
        em.agent.speed = startSpeed;
        health = startHealth;

    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {

        isDead = true;
        PlayerStats.Money += worth;

        Instantiate(ps, transform.position, Quaternion.identity);
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
        em.agent.speed = speed;
        StartCoroutine(WaitFor5());


    }
    //Wait for 5 seconds 
    IEnumerator WaitFor5()
    {
        yield return new WaitForSeconds(5);
        em.agent.speed = startSpeed;
    }


}

