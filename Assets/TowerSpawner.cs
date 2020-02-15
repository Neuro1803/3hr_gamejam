using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tower = Instantiate(towerToSpawn, transform.position, Quaternion.identity);
        tower.GetComponent<Tower>().statistics = GameObject.Find("StaticData").GetComponent<StaticData>().towerStats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
