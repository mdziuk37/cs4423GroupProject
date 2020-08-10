using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitAxe : MonoBehaviour
{

    private Collider weapon;
<<<<<<< HEAD
=======
    
>>>>>>> master
    [SerializeField]
    private ParticleSystem hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<SphereCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            ParticleSystem tempParticle =  Instantiate(hitEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),Quaternion.identity);
            Destroy(tempParticle.gameObject, .3f);
            
<<<<<<< HEAD
=======
            
            //For healthbar
            other.GetComponent<EnemyBehaviour>().Health -= 10;
            other.GetComponent<EnemyBehaviour>().gettingHit = true;
>>>>>>> master
        }
    }
}
