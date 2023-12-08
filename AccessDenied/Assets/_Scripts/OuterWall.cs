using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterWall : MonoBehaviour
{
    //Enemy specific behaviors
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.GetComponent<PlayerActor>() != null) {
            PlayerActor actor = collision.gameObject.GetComponent<PlayerActor>();
            actor.DepleteHitpoints(100);
        }
    }
}
