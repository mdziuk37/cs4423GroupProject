﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // the idea is to create a singleton player that will house the stats for the player. creating the player, leveling up, taking damage should use the functions in this class
    // this will be passed to every level that is loaded
    
    public Slider slider;

    public int maxHealth;

    public int playerClass;

    //probably gonna nix this
    public int mana;

    public int strength;

    public int wisdom;
    public int healthhold=0;

    public int dexterity;

    public int damage;

    public static Player instance;

    public Player player;

    public int health = 0;

    public int experience;

    private void Awake()
    {
        

        slider = GameObject.FindGameObjectWithTag("healthCanvas").GetComponent<Slider>();
        if (instance)
        {
            Debug.LogError("More than one Player in scene");
        }
        else
        {
            instance = this;


        }


        if(gameObject.name == "brute (1)")
        {
            playerClass = 1;
        }
        if(gameObject.name == "")
        {
            Debug.Log("no Character");

        }
       // playerClass = 1;

        createCharacter();

    }
    private void Update()
    {
        
        slider.value = health;
        slider.maxValue = maxHealth;
    
    }

    // use the menu to update the player class and then run create character
    public void createCharacter()
        {
        //brute starting stats
         if(playerClass == 1)
            {
            maxHealth = 250;
            strength = 5;
            wisdom = 1;
            dexterity =3;
            damage = 50;
            }
         //wizard starting stats
        if (playerClass == 2)
        {
            maxHealth = 100;
            strength = 1;
            wisdom = 5;
            dexterity = 3;
            damage = 30;
        }

        //archer starting stats
        if (playerClass == 3)
        {
            maxHealth = 120;
            strength = 1;
            wisdom = 3;
            dexterity = 5;
            damage = 25;
        }

        health = maxHealth;
        experience = 0;
    }


    public void levelUp()
    {   
        //brute level stats
        if (playerClass == 1)
        {
            maxHealth += 15;
            strength += 1;
            
        }
        //wizard level stats
        if (playerClass == 2)
        {
            maxHealth += 5;
            wisdom += 1;
           
        }

        //archer level stats
        if (playerClass == 3)
        {
            maxHealth += 5;
            dexterity += 10;
        }




    }


   

}
