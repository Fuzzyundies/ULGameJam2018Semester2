using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int health;
    private int actions;
    private int damage;
    private int[] actionQueue = new int[2];
    private bool ready;
    
	// Use this for initialization
	void Start ()
    {
        health = 3;
        actions = 2;
        damage = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (actionQueue[0] != 0 && actionQueue[1] != 0)
            ready = true;
        else
            ready = false;
	}

    public void AttackOfOpporunity()
    {

    }

    public void Block()
    {

    }

    public void Attack()
    {

    }

    public void Lunge()
    {

    }

    public void Advance()
    {

    }

    public void Retreat()
    {

    }

    public void CircleLeft()
    {

    }

    public void CircleRight()
    {

    }

    public void DealDamage(int damage)
    {

    }

    public void RecieveDamage(int damage)
    {

    }
}
