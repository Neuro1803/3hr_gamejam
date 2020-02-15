using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tower stats", menuName = "Tower Statistics")]
public class TowerStatistics : ScriptableObject
{
    public float damage;
    public float range;
    public float fireRate;
    public int multiTarget;

    public float slow;
    public float areaEffectRange;
    public float areaEffectDamage;
    public float damageOverTime;
    public float knockback;
}
