using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform goal;
    public float health;
    // public int damage;

    NavMeshAgent agent;

    void Start () {
        goal = GameObject.FindGameObjectWithTag("Wall").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    public void hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
