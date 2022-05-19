using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private GameObject ending;
    public NavMeshAgent agent;
    private Enemy enemy;
    private const float rotSpeed = 20f;
    void Start()
    {

        enemy = GetComponent<Enemy>();
        agent.updateRotation = false;
        agent.baseOffset = 2;
        ending = GameObject.Find("END");
        agent.SetDestination(ending.transform.position);
        agent.radius = 0.1f;

    }
    void Update()
    {
        InstantlyTurn(agent.destination);
        //gameObject.transform.Rotate(0, Time.deltaTime * 50, 0, Space.World);
        if (agent.transform.position.x < 12)
        {
            Destroy(gameObject);
            PlayerStats.Lives--;
            WaveSpawner.enemiesAlive--;
        }

    }
    private void InstantlyTurn(Vector3 destination)
    {
        //When on target -> dont rotate!
        if ((destination - transform.position).magnitude < 0.1f) return;

        Vector3 direction = (destination - transform.position).normalized;
        Quaternion qDir = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, qDir, Time.deltaTime * rotSpeed);
       

    }

}
