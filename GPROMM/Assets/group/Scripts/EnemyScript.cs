using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyScript : MonoBehaviour
{
    private GameObject Enemy;
    private int select;
    [SerializeField] public int Health;
    
    [FormerlySerializedAs("distance")] 
    [SerializeField] private float distanceToTarget;
 
    [SerializeField] private NavMeshAgent agent;
    private GameObject player;
   
   
    [SerializeField] private float distanceToPlayer;
    
    
    [SerializeField] private Animator anim;
    
    [SerializeField] private float attackCoolDown, lastAttackTime;





    void Start()
    {
        Health = 30;
        distanceToTarget = 2;
        
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

        // if (global::Health.)
        if (Health <= 0)
        {
            anim.SetBool("dead", true);
            Destroy(gameObject, 5);
            gameObject.GetComponent<EnemyScript>().enabled = false;
        }

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


    }



   

    private void followPlayer()
    {




        if (distanceToPlayer <= distanceToTarget)
        {
            attack();
            anim.SetBool("GettingHit", false);

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
        anim.SetBool("GettingHit", true);
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
        if(other.tag == "Player")
        {

        }
        if(other.tag == "weapon")
        {
            Health -= Player.instance.damage;
            Debug.Log("enemy hit for:");
            Debug.Log(Player.instance.damage.ToString());
        }
    }


}
    