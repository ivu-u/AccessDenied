using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActor : Actor
{
    public GameObject deathEffect;

    protected override void Faint() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameManager.Instance.AddScore(100);
        Destroy(gameObject);
    }
}
