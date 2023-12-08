using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;
    [SerializeField] private float minimumDistance;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (Vector2.Distance(transform.position, target.position) < minimumDistance) {
            // Move towards the player
            Vector2 moveDirection = target.position - transform.position;
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);

            // Rotate towards the player
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        // else with melee attack code
    }
}
