using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    public GameObject deathEffect;

    protected override void Faint() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }
}
