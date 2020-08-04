using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{

    
    

    private Collider weapon;
    [SerializeField]
    private ParticleSystem hitEffect;

    GameObject targets;
    float _arrowspeed;
    private int i = 0;

    [SerializeField]
    float _arrowspeedin = 10;
    // Start is called before the first frame update
    void Start()
    {
        print(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cinemachine.CinemachineBrain>().ActiveVirtualCamera.Name);
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cinemachine.CinemachineBrain>().ActiveVirtualCamera.Name == "CM vcam2")
        {
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * _arrowspeedin;
            i = 1;
            print(i);
        }
        else
        {
            targets = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cinemachine.CinemachineBrain>().ActiveVirtualCamera.LookAt.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            print(targets.ToString());
            _arrowspeed = _arrowspeedin * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targets.transform.position, _arrowspeed);

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            //this is how we will modify damage based on player stats
          //  other.gameObject.GetComponent<enemyScript>().health -= Player.instance.dexterity * Player.instance.damage;
            ParticleSystem tempParticle =  Instantiate(hitEffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),Quaternion.identity);
            Destroy(tempParticle.gameObject, .3f);
            Destroy(gameObject);
            
        }
    }
}
