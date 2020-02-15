using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public int speed;

    public bool canAttack = false;

    public void Update() {
        if (canAttack) {

        } else {
            float translation = -1 * speed * Time.deltaTime;
            transform.Translate(0, 0, translation, Space.World);
        }
    }

    private void OnCollisionEnter(Collision other) {
        canAttack = true;
    }

    private void OnCollisionExit(Collision other) {
        canAttack = false;
    }
}
