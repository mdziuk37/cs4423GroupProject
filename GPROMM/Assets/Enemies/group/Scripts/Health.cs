using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image foreGroundImage;
    [SerializeField] private GameObject Enemy;
    private GameObject mainPlayer;
    private int maxHealth = 100;
    public int currentHealth;
    private int oldHealth;
    [SerializeField] private float updateSpeedSeconds = 0f;

    public event  Action<float> onHealthPctChange = delegate {  };


    private void OnEnable() 
    {
        currentHealth = maxHealth;
    }

    private void modifyHealth(int amount)
    {
        currentHealth += amount;
        
        Enemy.GetComponent<Animator>().SetInteger("Health", Enemy.GetComponent<EnemyBehaviour>().Health);
        float currentHealthPct = (float) currentHealth / (float) maxHealth;
        onHealthPctChange(currentHealthPct);
       
    }

   
     private void Update()
     {
         
            if (Enemy.GetComponent<EnemyBehaviour>().gettingHit)
            {
                
                modifyHealth((-10));
                
            }

            Enemy.GetComponent<EnemyBehaviour>().gettingHit = false;
     }

    void Awake()
    {
        GetComponentInParent<Health>().onHealthPctChange += HandleHealthChange;
        currentHealth = Enemy.gameObject.GetComponent<EnemyBehaviour>().Health;
    }


    private void HandleHealthChange(float Pct)
    {
        StartCoroutine(changeToPct(Pct));
    }

    private IEnumerator changeToPct(float Pct)
    {
        float preChange = foreGroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreGroundImage.fillAmount = Mathf.Lerp(preChange,Pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foreGroundImage.fillAmount = Pct;
    }

    

    
    
}

