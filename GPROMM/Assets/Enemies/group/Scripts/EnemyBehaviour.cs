using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
  [SerializeField] private GameObject Enemy;
    private int select;
    [SerializeField] public int Health;
    public bool gettingHit;
   
    [SerializeField] private float distanceToTarget;
 
    [SerializeField] private NavMeshAgent agent;
    private GameObject player;
   
   
    [SerializeField] private float distanceToPlayer;
    
    
    [SerializeField] private Animator anim;
    
    [SerializeField] private float attackCoolDown, lastAttackTime;





    void Start()
    {
        Health = 100;
        distanceToTarget = 5;
        gettingHit = false;
        lastAttackTime = 0;
        attackCoolDown = .001f;
        anim.SetInteger("Speed", 0);
        player = GameObject.FindWithTag("Player");
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        gettingHit = false;
        player = GameObject.FindWithTag("Player");
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (!player)
        {
            idle();
        }
        
        if (distanceToPlayer <= 15)
        {
            followPlayer();
        }
        else
        {
            idle();
        }


        if (Health < 1)
        {
            Destroy(Enemy,4);
        }
    }



   

    private void followPlayer()
    {




        if (distanceToPlayer <= distanceToTarget)
        {
            attack();
            

        }
        else
        {
            run();
        }
        
    }

    private void attack()
    {
        agent.isStopped = true;
       
        anim.SetInteger("Speed", 1);
        anim.SetInteger("Health", Health);
        anim.SetBool("IsNextToTarget", true);
       
    }
    

    private void walk()
    {
        agent.SetDestination(player.transform.position);
        agent.isStopped = false;
        anim.SetInteger("Speed", 2);
        anim.SetBool("IsNextToTarget", false);
        
    }

    private void run()
    {
        agent.SetDestination(player.transform.position);
        agent.isStopped = false;
        
        anim.SetInteger("Speed", 4);
        anim.SetBool("IsNextToTarget", false);
    }

    private void idle()
    {
       agent.isStopped = true;
        
        anim.SetInteger("Speed", 0);
        anim.SetBool("IsNextToTarget", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //reduce player health on hith
        throw new NotImplementedException();
    }
}
    
