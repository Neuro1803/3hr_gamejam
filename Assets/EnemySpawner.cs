﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StaticData staticData = GameObject.Find("StaticData").GetComponent<StaticData>();
        enemyCount = staticData.levelNumber * 4 + 6;
        StartCoroutine(SpawnCorutine());
    }

    IEnumerator SpawnCorutine()
    {
        for(int i = 0; i <= enemyCount; i++)
        {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
