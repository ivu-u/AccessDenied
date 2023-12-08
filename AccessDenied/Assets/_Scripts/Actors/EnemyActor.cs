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

    //Enemy specific behaviors
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.GetComponent<PlayerActor>() != null) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            PlayerActor actor = collision.gameObject.GetComponent<PlayerActor>();
            actor.DepleteHitpoints(1);
            Faint();
        }
    }
}
