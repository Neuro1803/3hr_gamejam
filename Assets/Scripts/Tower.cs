using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public float damage;
    public TowerStatistics statistics;
    public GameObject target;
    public float timeSinceLastShoot;

    private float timerToEnd = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        damage = statistics.damage;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy"));
        if (!target) {
                timerToEnd -= Time.deltaTime;
        }

        if (timeSinceLastShoot >= 1/statistics.fireRate && target) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, statistics.range)) {
                Debug.DrawRay(transform.position, (target.transform.position - transform.position) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Enemy>().hit(damage);
                Debug.Log("HIT");
                timerToEnd = 10.0f;
            }
            else
            {
                timerToEnd -= Time.deltaTime;
            }
            timeSinceLastShoot = 0;
        } else {
            timeSinceLastShoot += Time.deltaTime;
        }

        if(timerToEnd <=0)
        {
            SceneManager.LoadScene("FActory");
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
