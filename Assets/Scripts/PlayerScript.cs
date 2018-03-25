using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAction
{
    ADVANCE,
    CIRCLE_LEFT,
    CIRCLE_RIGHT,
    RETREAT,
    ATTACK,
    PARRY,
    LUNGE,
    NONE,
}

public class PlayerScript : MonoBehaviour
{
    Vector3 moveVector;
    private RaycastHit ray;
    private int health;
    private int actions;
    private int damage;
    private PlayerAction[] actionQueue = new PlayerAction[2];
    private bool ready;
    private float distance = 2;
    private float moveSpeed = 20;
    private Vector3 direction;
    private Vector3 destination;

    // Use this for initialization
    void Start ()
    {
        //actionQueue[1]
        health = 3;
        actions = 2;
        damage = 2;
        ClearQueue();
        //PlayerAction a = PlayerAction.ADVANCE;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (actionQueue[0] != PlayerAction.NONE && actionQueue[1] != PlayerAction.NONE)
            ready = true;
        else
            ready = false;
        if (ready)
            InitiateAction();
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
        Debug.Log("called");
        if (Physics.Raycast(transform.position, transform.forward, out ray, distance))
        {
            Debug.Log("in");
            PlayerAction a = PlayerAction.ADVANCE;
            actionQueue[ArrayPosition()] = a;
        }
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

    private int ArrayPosition()
    {
        if (actionQueue[0] == PlayerAction.NONE)
            return 0;
        else
            return 1;
    }

    private void InitiateAction()
    {
        
        for(int i = 0; i < actionQueue.Length; i++)
        {
           if(actionQueue[i] == PlayerAction.ADVANCE)
            {
                moveVector.Set(0f, 1, 0f);
                moveVector = moveVector.normalized * moveSpeed * Time.deltaTime;
                gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + moveVector);
                /*direction = ray.point - transform.position;
                destination = ray.point;
                direction.Normalize();
                gameObject.GetComponent<Rigidbody>().AddForce((direction) * moveSpeed);*/
            }
        }
        ClearQueue();

    }

    private void ClearQueue()
    {
        actionQueue[0] = PlayerAction.NONE;
        actionQueue[1] = PlayerAction.NONE;
    }
}
