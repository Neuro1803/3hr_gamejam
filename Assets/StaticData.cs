using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public TowerStatistics towerStats;
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
