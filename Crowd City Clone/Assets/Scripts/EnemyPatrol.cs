using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform player;

    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;
    
    //Patrolling
    [SerializeField] private Vector3 walkPoint;
    
    [SerializeField] private bool walkPointSet, patrol, captured;
    
    [SerializeField] private float walkPointRange;
    
    //States
    public bool playerIsInSightRange;


    private void Start()
    {
        //StateChoose();
    }

    private void Update()
    {
        
        if (patrol) Patrolling();
        if (!patrol && captured) Chasing();
    }

    void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        else
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            //StateChoose();
            //patrol = false;
        }
    }

    void Chasing()
    {
        agent.SetDestination(player.position);
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void Staking()
    {
        Invoke("StateChoose", Random.Range(1,3));
    }

    void StateChoose()
    {
        int choose = Random.Range(0, 1);
        Debug.Log(choose);
        switch (choose)
        {
            case 0:
                patrol = true;
                break;
                
            case 1:
                Staking();
                break;
        }
    }
}
