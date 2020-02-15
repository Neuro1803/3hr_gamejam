using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform goal;
    public int health;
    public int damage;

    NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 
    }

    public void hit(float demage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
