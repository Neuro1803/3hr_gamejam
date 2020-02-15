using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage;
    public TowerStatistics statistics;
    public GameObject target;
    public float timeSinceLastShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        damage = statistics.damage;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy"));

        if (timeSinceLastShoot >= 1/statistics.fireRate) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, statistics.range)) {
                Debug.DrawRay(transform.position, (target.transform.position - transform.position) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Enemy>().hit(damage);
                Debug.Log("HIT");
            }
            timeSinceLastShoot = 0;
        } else {
            timeSinceLastShoot += Time.deltaTime;
        }
    }

    private GameObject FindClosestEnemy(GameObject[] enemies) {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
     
        return bestTarget;
    }
}
